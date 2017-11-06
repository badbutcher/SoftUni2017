namespace Car.Services
{
    using System.Collections.Generic;
    using Car.Services.Models;
    using Cars.Data.Models;

    public interface ICarService
    {
        IEnumerable<CarModel> CarsFromMake(string make);

        IEnumerable<CarPartsModel> CarsParts();

        IEnumerable<CarModel> All();

        void AddCar(string make, string model, long travelledDistance);
    }
}