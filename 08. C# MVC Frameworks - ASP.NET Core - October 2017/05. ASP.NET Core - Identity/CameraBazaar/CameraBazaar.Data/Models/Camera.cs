namespace CameraBazaar.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using CameraBazaar.Data.Models.Enums;

    public class Camera
    {
        public int Id { get; set; }

        public CameraMake Make { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        public decimal Price { get; set; }

        [Range(0, 100)]
        public int Quantity { get; set; }

        [Display(Name = "Min Shutter Speed")]
        [Range(1, 30)]
        public int MinShutterSpeed { get; set; }

        [Display(Name = "Max Shutter Speed")]
        [Range(2000, 8000)]
        public int MaxShutterSpeed { get; set; }

        [Display(Name = "Min ISO")]
        public CameraMinIso MinIso { get; set; }

        [Display(Name = "Max ISO")]
        [Range(200, 409600)]
        public int MaxIso { get; set; }

        [Display(Name = "Full Frame")]
        public bool IsFullFrame { get; set; }

        [Display(Name = "Video Resolution")]
        [MaxLength(15)]
        public string VideoResolution { get; set; }

        [Display(Name = "Light Metering")]
        public LightMetering LightMetering { get; set; }

        [Required]
        [MaxLength(6000)]
        public string Description { get; set; }

        [Display(Name = "Image URL")]
        [Required]
        [MinLength(10)]
        [MaxLength(2000)]
        public string ImageUrl { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}