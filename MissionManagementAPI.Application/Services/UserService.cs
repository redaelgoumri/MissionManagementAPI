using MissionManagementAPI.Application.Interfaces;
using MissionManagementAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MissionManagementAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task CreateAsync(User user, string password)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            user.CodeAgent = Guid.NewGuid().ToString(); // or set manually
            await _userRepository.AddAsync(user);
        }

        public async Task DeleteAsync(string codeAgent)
        {
            await _userRepository.DeleteAsync(codeAgent);
        }
    }
}
