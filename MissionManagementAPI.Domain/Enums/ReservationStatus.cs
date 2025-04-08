using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionManagementAPI.Domain.Enums
{
    public enum ReservationStatus
    {
        Brouillon = 0,        // Créée mais pas encore soumise
        Soumise = 1,          // Envoyée à N+1
        ApprouveN1 = 2,       // Validée par N+1
        ApprouveDAAJ = 3,     // Validée par DAAJ
        TraiteeParParc = 4,   // Finalisée
        Rejetee = 5           // Rejetée
    }
}
