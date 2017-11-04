namespace Car.Services.Models
{
    using System.Collections.Generic;

    public class CarPartsModel : CarModel
    {
        public IEnumerable<PartModel> Parts { get; set; }
    }
}