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
        public string GetBanners()
        {
            List<Banner> banners = bannersManager.GetBannersAsync().Result;
            string result = "{\n";
            foreach (Banner banner in banners)
            {
                result +=
                    "    {\n" +
                    "        'Id': " + banner.Id + ",\n"
                    + "        'Name': " + banner.Name + ",\n"
                    + "        'Cards': [";
                if (banner.BannerCards != null)
                {
                    foreach (Card card in banner.BannerCards)
                    {
                        result += card.Name + ", ";
                    }
                    result = result.Substring(0, result.Length - 2);
                }
                result += "]\n    },\n";
            }
            result = result.Substring(0, result.Length - 2);
            result += "\n}";
            return result;
        }

        [HttpGet("{id}")]
        public string GetBanner(int id) 
        {
            string result = "";
            var banner = bannersManager.GetBannerAsync(id).Result;
            if (banner == null) 
            {
                result = "Specified Id does not match any existing banner";
            }
            else
            {
                result =
                    "{\n" +
                    "    'Id': " + banner.Id + ",\n"
                    + "    'Name': " + banner.Name + ",\n"
                    + "    'Cards': [";
                foreach (Card card in banner.BannerCards)
                {
                    result += card.Name + ", ";
                }
                result = result.Substring(0, result.Length - 2);
                result += "]\n}";
            }
            return result;
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
