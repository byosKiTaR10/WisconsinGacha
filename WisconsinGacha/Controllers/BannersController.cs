using Microsoft.AspNetCore.Mvc;
using WisconsinGacha.Interfaces;
using WisconsinGacha.Models;

namespace WisconsinGacha.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BannersController : ControllerBase
    {
        private readonly IBannersManager bannersManager;

        public BannersController(IBannersManager bannersManager)
        {
            this.bannersManager = bannersManager;
        }

        [HttpGet]
        public List<Banner> GetBanners()
        {
            List<Banner> banners = bannersManager.GetBannersAsync().Result;
            return banners;
        }

        [HttpGet("{id}")]
        public Banner GetBanner(int id) 
        {
            var banner = bannersManager.GetBannerAsync(id).Result;
            return banner;
        }

        [HttpPost]
        public string CreateBanner([FromBody] Banner banner) 
        {
            bool bannerCreated = bannersManager.CreateBannerAsync(banner).Result;
            string result = "";
            if (bannerCreated) 
            {
                result = "Banner was created successfully.";
            }
            else
            {
                result = "Banner could not be created, check if it already exists.";
            }
            return result;
        }

        [HttpPut]
        public string UpdateBanner([FromBody] Banner banner) 
        {
            string result = "";
            if (bannersManager.UpdateBannerAsync(banner).Result) 
            {
                result = "Banner has been updated successfully.";
            }
            else
            {
                result = "Banner could not be updated";
            }
            return result;
        }

        [HttpDelete]
        public string DeleteBanner(int id)
        {
            bool isBannerDeleted = bannersManager.DeleteBannerAsync(id).Result;
            string result = "";
            if (isBannerDeleted)
            {
                result = "Banner was deleted successfully.";
            }
            else
            {
                result = "Banner could not be deleted.";
            }
            return result;
        }
    }
}
