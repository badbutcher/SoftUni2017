namespace Cars.Models.Cars
{
    using System.Collections.Generic;
    using Car.Services.Models;

    public class CarsMakeModel
    {
        public IEnumerable<CarModel> Cars { get; set; }
    }
}