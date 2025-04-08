using MissionManagementAPI.Domain.Entities;

namespace MissionManagementAPI.Application.Interfaces
{
    public interface IPassengerService
    {
        Task<IEnumerable<Passenger>> GetPassengersByReservation(int reservationId);
        Task AddPassenger(int reservationId, Passenger passenger);
        Task DeletePassenger(int passengerId);
    }
}
