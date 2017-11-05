namespace Cars.Models.Cars
{
    using System.Collections.Generic;
    using Car.Services.Models;

    public class CarsPartsModel
    {
        public IEnumerable<CarPartsModel> CarsParts { get; set; }
    }
}