using System.Collections.Generic;
using Car.Services.Models;

namespace Cars.Models.Cars
{
    public class CarsPartsModel
    {
        public IEnumerable<CarPartsModel> CarsParts { get; set; }
    }
}