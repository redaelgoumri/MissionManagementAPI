using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionManagementAPI.Domain.Entities
{
    public class Passenger
    {
        public int Id { get; set; }

        public string NomComplet { get; set; }

        public string Fonction { get; set; }

        public string Organisme { get; set; }

        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; }
    }
}

