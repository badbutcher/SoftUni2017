namespace Car.Services.Implementastions
{
    using System.Collections.Generic;
    using System.Linq;
    using Car.Services.Models;
    using Cars.Data;

    public class CarService : ICarService
    {
        private readonly CarDbContext db;

        public CarService(CarDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CarModel> All()
        {
            var cars = this.db.Cars
                   .Select(a => new CarModel
                   {
                       Make = a.Make,
                       Model = a.Model,
                       TravlledDistance = a.TravelledDistance
                   })
                   .ToList();

            return cars;
        }

        public IEnumerable<CarModel> CarsFromMake(string make)
        {
            var cars = this.db.Cars.Where(a => a.Make.ToLower() == make.ToLower())
                .Select(a => new CarModel
                {
                    Make = a.Make,
                    Model = a.Model,
                    TravlledDistance = a.TravelledDistance
                })
                .OrderBy(a => a.Model)
                .ThenByDescending(a => a.TravlledDistance)
                .ToList();

            return cars;
        }

        public IEnumerable<CarPartsModel> CarsParts()
        {
            var carsParts = this.db.Cars
                .Select(a => new CarPartsModel
                {
                    Make = a.Make,
                    Model = a.Model,
                    TravlledDistance = a.TravelledDistance,
                    Parts = a.Parts.Select(p => new PartModel
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price,
                        Supplier = p.Part.Supplier.Name
                    })
                })
                .ToList();

            return carsParts;
        }
    }
}