using MissionManagementAPI.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MissionManagementAPI.Domain.Entities
{
    public class Reservation
    {
        [Key]
        public int IdDemande { get; set; }
        public string RefDemande { get; set; }
        public string IdDemandeur { get; set; }
        public string ServiceDemandeur { get; set; }
        public string Beneficiaire { get; set; }
        public string Objet { get; set; }

        public DateTime DateDepart { get; set; }
        public string HeureDepart { get; set; }

        public DateTime DateRetour { get; set; }
        public string HeureRetour { get; set; }

        public int? IdTypeMission { get; set; }
        public int? IdUsage { get; set; }

        public int? IdDestinationDepart { get; set; }
        public int? IdSituationDepart { get; set; }
        public int? IdAdresseDepart { get; set; }

        public int? IdDestinationDestination { get; set; }
        public int? IdSituationDestination { get; set; }
        public int? IdAdresseDestination { get; set; }

        public double? KmPrevu { get; set; }

        public DateTime? DateCreation { get; set; }
        public string IdCreateur { get; set; }

        public int IdStatut { get; set; }
        public DateTime? DateStatut { get; set; }

        public bool? EstDirecte { get; set; }
        public int? IdModeTraitement { get; set; }

        public int? IdDemandeMere { get; set; }
        public bool? DdeGroupee { get; set; }

        public string Observation { get; set; }

        public double? KmRoute { get; set; }
        public double? KmPiste { get; set; }
        public string HeureManutention { get; set; }

        public DateTime? DateReeDepart { get; set; }
        public string HeureReeDepart { get; set; }

        public DateTime? DateDemande { get; set; }
        public string HeureDemande { get; set; }

        public string VilleDepart { get; set; }
        public string ServiceMission { get; set; }

        public string MotifRejet { get; set; }
        public DateTime? DateRejet { get; set; }

        public double? Kilometrage { get; set; }

        public ReservationStatus Statut { get; set; } = ReservationStatus.Brouillon;

        public ICollection<Passenger> Passengers { get; set; }

    }
}
