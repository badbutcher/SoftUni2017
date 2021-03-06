﻿namespace MyCoolWebServer.GameStoreApplication.ViewModels.Admin
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AddGameViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string VideoId { get; set; }

        [Required]
        public string Image { get; set; }

        public double Size { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }
    }
}