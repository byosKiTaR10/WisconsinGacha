using System.ComponentModel.DataAnnotations;

namespace WisconsinGacha.Models
{
    public class Banner
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public List<Card>? BannerCards { get; set; }
    }
}
