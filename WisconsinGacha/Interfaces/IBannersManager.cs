using WisconsinGacha.Models;

namespace WisconsinGacha.Interfaces
{
    public interface IBannersManager
    {
        Task<bool> CreateBannerAsync(Banner banner);
        Task<bool> DeleteBannerAsync(int id);
        Task<Banner> GetBannerAsync(int id);
        Task<List<Banner>> GetBannersAsync();
        Task<bool> UpdateBannerAsync(Banner banner);
    }
}