using Microsoft.EntityFrameworkCore;
using MissionManagementAPI.Application.Interfaces;
using MissionManagementAPI.Domain.Entities;
using MissionManagementAPI.Infrastructure.Data;

namespace MissionManagementAPI.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var sql = "SELECT * FROM USERS WHERE LOWER(EMAIL) = :email";

            return await _context.Users
                .FromSqlRaw(sql, new Oracle.ManagedDataAccess.Client.OracleParameter("email", email.ToLower()))
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    


        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string codeAgent)
        {
            var user = await _context.Users.FindAsync(codeAgent);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
