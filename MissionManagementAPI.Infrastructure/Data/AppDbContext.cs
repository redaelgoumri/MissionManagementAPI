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
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");
                entity.HasKey(u => u.CodeAgent); // 👈 important!

                entity.Property(u => u.Email).HasColumnName("EMAIL");
                entity.Property(u => u.PasswordHash).HasColumnName("PASSWORDHASH");
                entity.Property(u => u.CodeAgent).HasColumnName("CODEAGENT");
                entity.Property(u => u.NomPrenomAgent).HasColumnName("NOMPRENOMAGENT");
                entity.Property(u => u.Departement).HasColumnName("DEPARTEMENT");
                entity.Property(u => u.Role).HasColumnName("ROLE");
            });

            modelBuilder.Entity<Reservation>().ToTable("RESERVATIONS");
            modelBuilder.Entity<Passenger>().ToTable("PASSENGERS");

            modelBuilder.Entity<Passenger>()
                .HasOne(p => p.Reservation)
                .WithMany(r => r.Passengers)
                .HasForeignKey(p => p.ReservationId);

            base.OnModelCreating(modelBuilder);
        }


    }
}
