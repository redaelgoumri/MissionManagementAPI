using Microsoft.EntityFrameworkCore;
using MissionManagementAPI.Application.Interfaces;
using MissionManagementAPI.Domain.Entities;
using MissionManagementAPI.Infrastructure.Data;

namespace MissionManagementAPI.Infrastructure.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly AppDbContext _context;

        public PassengerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Passenger>> GetByReservationIdAsync(int reservationId)
        {
            return await _context.Passengers
                .Where(p => p.ReservationId == reservationId)
                .ToListAsync();
        }

        public async Task<Passenger> GetByIdAsync(int id)
        {
            return await _context.Passengers.FindAsync(id);
        }

        public async Task AddAsync(Passenger passenger)
        {
            _context.Passengers.Add(passenger);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger != null)
            {
                _context.Passengers.Remove(passenger);
                await _context.SaveChangesAsync();
            }
        }
    }
}
