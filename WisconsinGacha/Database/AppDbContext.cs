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
    }
}
