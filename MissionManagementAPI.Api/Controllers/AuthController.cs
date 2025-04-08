using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissionManagementAPI.Application.DTOs;
using MissionManagementAPI.Application.Interfaces;

namespace MissionManagementAPI.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequestDto dto)
        {
            try
            {
                var result = await _authService.LoginAsync(dto);
                return Ok(result);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Invalid email or password.");
            }
        }

        // Optional: only for admin-created accounts
        // Can be moved into a dedicated AdminController later
        [HttpPost("register")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register([FromBody] AuthRequestDto dto, [FromQuery] string role)
        {
            await _authService.RegisterAsync(dto, role);
            return Ok("User registered successfully.");
        }
    }
}
