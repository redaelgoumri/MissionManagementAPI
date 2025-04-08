using MissionManagementAPI.Application.Interfaces;
using MissionManagementAPI.Domain.Entities;

namespace MissionManagementAPI.Application.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _repository;

        public PassengerService(IPassengerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Passenger>> GetPassengersByReservation(int reservationId)
        {
            return await _repository.GetByReservationIdAsync(reservationId);
        }

        public async Task AddPassenger(int reservationId, Passenger passenger)
        {
            passenger.ReservationId = reservationId;
            await _repository.AddAsync(passenger);
        }

        public async Task DeletePassenger(int passengerId)
        {
            await _repository.DeleteAsync(passengerId);
        }
    }
}
