using Microsoft.EntityFrameworkCore;

namespace FeeSystem.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Resident> Residents { get; set; }
    }
}
