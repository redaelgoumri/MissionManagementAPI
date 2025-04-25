using System.ComponentModel.DataAnnotations;

namespace MissionManagementAPI.Domain.Entities
{
    public class User
    {
        [Key]
        public string CodeAgent { get; set; }   
        public string NomPrenomAgent { get; set; }
        public string Email { get; set; }        
        public string PasswordHash { get; set; } 

        public string Role { get; set; }         // Ex: "Admin", "DAAJ", "Directeur", "Employe"
        public string Departement { get; set; } 
    }
}
