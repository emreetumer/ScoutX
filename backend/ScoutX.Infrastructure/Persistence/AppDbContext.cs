using Microsoft.EntityFrameworkCore;
using ScoutX.Domain.Entites;

namespace ScoutX.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }
        public DbSet<Player> Players => Set<Player>(); // Veritabanında "Players" tablosu oluşur

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(p => p.MarketValue)
                      .HasPrecision(18, 4); // örneğin 4 basamak ondalıklı sayı istiyorsan
            });
        }
    }
}
