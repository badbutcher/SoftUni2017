namespace CameraBazaar.Web.Models.Cameras
{
    using CameraBazaar.Data.Models.Enums;

    public class CameraBasicInfoViewModel
    {
        public CameraMake Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }
    }
}