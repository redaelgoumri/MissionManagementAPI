using MissionManagementAPI.Domain.Entities;

namespace MissionManagementAPI.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task DeleteAsync(string codeAgent);
    }
}
