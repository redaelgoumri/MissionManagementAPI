using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionManagementAPI.Domain.Entities
{
    public class ReservationStatusHistory
    {
        public int Id { get; set; }

        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        public string NewStatus { get; set; }   // Store as string for readability
        public string ChangedBy { get; set; }   // Optional: code agent or role
        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
    }
}

