using Microsoft.EntityFrameworkCore;
using MissionManagementAPI.Domain.Entities;

namespace MissionManagementAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        // public DbSet<ReservationStatusHistory> ReservationStatusHistories { get; set; }
        public DbSet<Passenger> Passengers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Reservation entity
            modelBuilder.HasDefaultSchema("missionmanagement");
            base.OnModelCreating(modelBuilder);

            // Configure the ReservationStatusHistory entity
            /*modelBuilder.Entity<ReservationStatusHistory>()
            .HasOne(h => h.Reservation)
            .WithMany()
            .HasForeignKey(h => h.ReservationId);*/

            modelBuilder.Entity<Passenger>()
            .HasOne(p => p.Reservation)
            .WithMany(r => r.Passengers)
            .HasForeignKey(p => p.ReservationId);


        }
    }
}
