namespace Car.Services
{
    using System.Collections.Generic;
    using Car.Services.Models;

    public interface ICarService
    {
        IEnumerable<CarModel> CarsFromMake(string make);

        IEnumerable<CarPartsModel> CarsParts();

        IEnumerable<CarModel> All();
    }
}