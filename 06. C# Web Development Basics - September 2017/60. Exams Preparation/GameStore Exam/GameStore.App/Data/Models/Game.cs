namespace GameStore.App.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public double Size { get; set; }

        [Required]
        public string VideoId { get; set; }

        [Required]
        public string ThumbnailUrl { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}