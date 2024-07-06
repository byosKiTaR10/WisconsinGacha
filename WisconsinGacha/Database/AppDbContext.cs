using Microsoft.EntityFrameworkCore;
using WisconsinGacha.Models;

namespace WisconsinGacha.Database
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Banner> Banners { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banner>()
                .HasMany(b => b.BannerCards)
                .WithMany(c => c.Banners)
                .UsingEntity<Dictionary<string, object>>(
                    "BannerCard",
                    bc => bc.HasOne<Card>().WithMany().HasForeignKey("CardId"),
                    bc => bc.HasOne<Banner>().WithMany().HasForeignKey("BannerId"));
        }
    }
}
