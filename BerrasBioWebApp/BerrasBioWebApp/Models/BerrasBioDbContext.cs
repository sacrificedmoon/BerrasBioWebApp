using Microsoft.EntityFrameworkCore;

namespace BerrasBioWebApp
{
    public partial class BerrasBioDbContext : DbContext
    {
        public BerrasBioDbContext(DbContextOptions<BerrasBioDbContext> options) : base(options)
        {
        }

        public DbSet<FilmSchedule> FilmSchedule { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<Salon> Salon { get; set; }
        public DbSet<Booking> Booking { get; set; }
    }
}
