using MissionManagementAPI.Domain.Entities;

namespace MissionManagementAPI.Application.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllReservations();
        Task<Reservation> GetReservationById(int id);
        Task CreateReservation(Reservation reservation);
        Task UpdateReservation(Reservation reservation);
        Task DeleteReservation(int id);
        Task SubmitReservation(int id);
        Task ApproveByN1(int id);
        Task ApproveByDAAJ(int id);
        Task FinaliseParParc(int id);
        Task Reject(int id, string motif);

    }
}
