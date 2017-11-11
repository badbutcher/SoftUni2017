namespace CarDealer.Services
{
    using System.Collections.Generic;
    using CarDealer.Services.Models.Cars;

    public interface ICarService
    {
        IEnumerable<CarModel> ByMake(string make);

        IEnumerable<CarWithPartsModel> WithParts();

        void Create(string make, string model, long travelledDistance, IEnumerable<int> parts);
    }
}