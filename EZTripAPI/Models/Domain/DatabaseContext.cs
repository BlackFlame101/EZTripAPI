using Microsoft.EntityFrameworkCore;

namespace EZTripAPI.Models.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts)
        {

        }

        public DbSet<Transportation> Transportation { get; set; }
        public DbSet<Trips> Trips { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Registration> Registration { get; set; }
    }
}
