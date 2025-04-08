using MissionManagementAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionManagementAPI.Application.Interfaces
{
    public interface IPassengerRepository
    {
        Task<IEnumerable<Passenger>> GetByReservationIdAsync(int reservationId);
        Task<Passenger> GetByIdAsync(int id);
        Task AddAsync(Passenger passenger);
        Task DeleteAsync(int id);
    }
}

