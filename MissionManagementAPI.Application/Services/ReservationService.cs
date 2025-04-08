using MissionManagementAPI.Application.Interfaces;
using MissionManagementAPI.Domain.Entities;
using MissionManagementAPI.Domain.Enums;
using MissionManagementAPI.Infrastructure.Services;
using System;

namespace MissionManagementAPI.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _repository;
        private readonly INotificationSender _notificationSender;
        private readonly ICurrentUserService _currentUser;
        //private readonly IManagerRepository _managerRepo;

        public ReservationService(
            IReservationRepository repo,
            ICurrentUserService currentUser)
            //IManagerRepository managerRepo)
        {
            _repository = repo;
            _currentUser = currentUser;
            //_managerRepo = managerRepo;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateReservation(Reservation reservation)
        {
            await _repository.AddAsync(reservation);
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            await _repository.UpdateAsync(reservation);
        }

        public async Task DeleteReservation(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task SubmitReservation(int id)
        {
            var reservation = await _repository.GetByIdAsync(id);
            if (reservation == null)
                throw new Exception("Demande introuvable");

            reservation.Statut = ReservationStatus.Soumise;
            await _repository.UpdateAsync(reservation);

            // Notification System
            var senderEmail = _currentUser.Email;
            var now = DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm");
            var service = "reservation.Service"; // or reservation.Objet, etc.

            var notifMessage = $"Nouvelle demande de mission soumise par {senderEmail} le {now}. Objet: {service}.";

            await _notificationSender.SendToUserAsync("managerEmail", notifMessage);

        }

        public async Task ApproveByN1(int id)
        {
            var reservation = await _repository.GetByIdAsync(id);
            if (reservation == null || reservation.Statut != ReservationStatus.Soumise)
                throw new Exception("Demande non soumise");

            // var managerEmail = await _managerRepo.GetManagerEmailByDepartment(reservation.Departement);
            if (_currentUser.Email != "managerEmail@involys.ma")
                throw new UnauthorizedAccessException("Vous n'êtes pas autorisé à valider cette demande.");

            reservation.Statut = ReservationStatus.ApprouveN1;
            await _repository.UpdateAsync(reservation);
        }

        public async Task ApproveByDAAJ(int id)
        {
            var reservation = await _repository.GetByIdAsync(id);
            if (reservation == null || reservation.Statut != ReservationStatus.ApprouveN1)
                throw new Exception("Non approuvée par N+1");

            if (_currentUser.Role != "DAAJ")
                throw new UnauthorizedAccessException("Seul un agent DAAJ peut valider cette étape.");

            reservation.Statut = ReservationStatus.ApprouveDAAJ;
            await _repository.UpdateAsync(reservation);
        }

        public async Task FinaliseParParc(int id)
        {
            var reservation = await _repository.GetByIdAsync(id);
            if (reservation == null || reservation.Statut != ReservationStatus.ApprouveDAAJ)
                throw new Exception("Non approuvée par DAAJ");

            if (_currentUser.Role != "Parc")
                throw new UnauthorizedAccessException("Seul le Parc Auto peut finaliser cette demande.");

            reservation.Statut = ReservationStatus.TraiteeParParc;
            await _repository.UpdateAsync(reservation);
        }

        public async Task Reject(int id, string motif)
        {
            var reservation = await _repository.GetByIdAsync(id);
            if (reservation == null || reservation.Statut == ReservationStatus.TraiteeParParc)
                throw new Exception("Impossible de rejeter cette demande");

            // Optional: Only allow N+1 or DAAJ or Admin to reject
            // var managerEmail = await _managerRepo.GetManagerEmailByDepartment(reservation.Departement);
            var isAllowed = _currentUser.Email == "managerEmail" || _currentUser.Role == "DAAJ" || _currentUser.Role == "Admin";
            if (!isAllowed)
                throw new UnauthorizedAccessException("Vous n'êtes pas autorisé à rejeter cette demande.");

            reservation.Statut = ReservationStatus.Rejetee;
            reservation.MotifRejet = motif;
            reservation.DateRejet = DateTime.Now;

            await _repository.UpdateAsync(reservation);
        }
    }
}
