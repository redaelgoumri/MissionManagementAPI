using MissionManagementAPI.Domain.Entities;

namespace MissionManagementAPI.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByEmailAsync(string email);
        Task CreateAsync(User user, string password);
        Task DeleteAsync(string codeAgent);
    }
}
