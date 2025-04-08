using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MissionManagementAPI.Domain.Entities;

namespace MissionManagementAPI.Application.Interfaces
{
    public interface IReservationHistoryRepository
    {
        Task AddStatusHistoryAsync(ReservationStatusHistory history);
        Task<IEnumerable<ReservationStatusHistory>> GetByReservationIdAsync(int reservationId);
    }
}
