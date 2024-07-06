using System.ComponentModel.DataAnnotations;

namespace WisconsinGacha.Models
{
    public class Card
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Image {  get; set; }
        [Required]
        public string? Anime { get; set; }
        [Required]
        public int Rarity { get; set; }
    }
}
