using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using MissionManagementAPI.Application.Interfaces;



namespace MissionManagementAPI.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public string Email { get; }
        public string Role { get; }
        public string CodeAgent { get; }
        public string Department { get; }

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            var user = contextAccessor.HttpContext?.User;

            Email = user?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            Role = user?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            CodeAgent = user?.Claims.FirstOrDefault(c => c.Type == "CodeAgent")?.Value;
            Department = user?.Claims.FirstOrDefault(c => c.Type == "Department")?.Value;

        }
    }
}
