using Microsoft.EntityFrameworkCore;
using WisconsinGacha.Interfaces;
using WisconsinGacha.Models;

namespace WisconsinGacha.Database
{
    public class BannersManager : IBannersManager
    {
        private readonly AppDbContext context;

        public BannersManager(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Banner>> GetBannersAsync()
        {
            return await context.Banners.ToListAsync();
        }

        public async Task<Banner> GetBannerAsync(int id)
        {
            var card = await context.Banners.FindAsync(id);
            return card;
        }

        public async Task<bool> CreateBannerAsync(Banner banner)
        {
            bool isNewBanner = false;
            if (context.Banners.FindAsync(banner.Id).Result == null && context.Banners.FirstOrDefaultAsync(x => x.Name.ToLower() == banner.Name.ToLower()).Result == null)
            {
                context.Banners.Add(banner);
                await context.SaveChangesAsync();
                isNewBanner = true;
            }
            return isNewBanner;
        }
        public async Task<bool> UpdateBannerAsync(Banner banner)
        {
            var existingBanner = await context.Banners.FindAsync(banner.Id);

            if (existingBanner != null)
            {
                existingBanner.Name = banner.Name;
                existingBanner.BannerCards = banner.BannerCards;
            }
            var recordsAffected = await context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> DeleteBannerAsync(int id)
        {
            bool isBannerDeleted = false;

            var banner = await context.Banners.FindAsync(id);

            if (banner != null)
            {
                context.Banners.Remove(banner);
                await context.SaveChangesAsync();
                isBannerDeleted = true;
            }
            return isBannerDeleted;
        }
    }
}
