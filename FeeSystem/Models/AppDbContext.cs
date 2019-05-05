using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FeeSystem.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<PaymentHistory> PaymentHistories {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PaymentHistory>()
                .HasOne(a => a.PricesHistory)
                .WithOne(b => b.PaymentHistory)
                .HasForeignKey<PaymentHistory>(b => b.PricesHistoryId);
        }
    }
}
