using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissionManagementAPI.Application.Interfaces;
using MissionManagementAPI.Domain.Entities;

namespace MissionManagementAPI.Api.Controllers
{
    [ApiController]
    [Route("api/admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpPost("users")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var user = new User
            {
                Email = request.Email,
                Role = request.Role,
                Departement = request.Departement,
                NomPrenomAgent = request.NomPrenomAgent
            };

            await _userService.CreateAsync(user, request.Password);
            return Ok("Utilisateur créé avec succès.");
        }

        [HttpDelete("users/{codeAgent}")]
        public async Task<IActionResult> DeleteUser(string codeAgent)
        {
            await _userService.DeleteAsync(codeAgent);
            return Ok("Utilisateur supprimé.");
        }
    }

    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Departement { get; set; }
        public string NomPrenomAgent { get; set; }
    }
}
