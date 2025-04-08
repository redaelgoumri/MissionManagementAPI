using MissionManagementAPI.Application.DTOs;

namespace MissionManagementAPI.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(AuthRequestDto dto);
        Task RegisterAsync(AuthRequestDto dto, string role); // for admin-initiated creation
    }
}
