﻿namespace WisconsinGacha.Models
{
    public class Banner
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Card>? BannerCards { get; set; }
    }
}
