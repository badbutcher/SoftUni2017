namespace CameraBazaar.Services.Models.Cameras
{
    using CameraBazaar.Data.Models.Enums;

    public class CameraBasicInfoModel
    {
        public int Id { get; set; }

        public CameraMake Make { get; set; }

        public string CameraModel { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }
    }
}