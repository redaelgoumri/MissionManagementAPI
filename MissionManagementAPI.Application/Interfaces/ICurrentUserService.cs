namespace MissionManagementAPI.Application.Interfaces
{
    public interface ICurrentUserService
    {
        string Email { get; }
        string Role { get; }
        string CodeAgent { get; }
        string Department { get; }
    }
}
