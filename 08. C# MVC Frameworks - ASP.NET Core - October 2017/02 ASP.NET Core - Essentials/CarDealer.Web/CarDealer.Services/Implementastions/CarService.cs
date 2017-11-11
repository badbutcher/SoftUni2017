namespace CarDealer.Services.Implementastions
{
    using System.Collections.Generic;
    using System.Linq;
    using CarDealer.Data;
    using CarDealer.Data.Models;
    using CarDealer.Services.Models.Cars;
    using CarDealer.Services.Models.Parts;

    public class CarService : ICarService
    {
        private readonly CarDealerDbContext db;

        public CarService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CarModel> ByMake(string make)
        {
            return this.db.Cars.Where(a => a.Make.ToLower() == make.ToLower())
                .OrderBy(a => a.Model)
                .ThenByDescending(a => a.TravelledDistance)
                .Select(a => new CarModel
                {
                    Make = a.Make,
                    Model = a.Model,
                    TravelledDistance = a.TravelledDistance
                })
                .ToList();
        }

        public void Create(string make, string model, long travelledDistance, IEnumerable<int> parts)
        {
            var existingPartIds = this.db.Parts
                .Where(a => parts.Contains(a.Id))
                .Select(a => a.Id)
                .ToList();

            var car = new Car
            {
                Make = make,
                Model = model,
                TravelledDistance = travelledDistance
            };

            foreach (var item in existingPartIds)
            {
                car.Parts.Add(new PartCar { PartId = item });
            }

            this.db.Cars.Add(car);
            this.db.SaveChanges();
        }

        public IEnumerable<CarWithPartsModel> WithParts()
        {
            var carsParts = this.db.Cars
               .OrderByDescending(p => p.Id)
               .Select(a => new CarWithPartsModel
               {
                   Make = a.Make,
                   Model = a.Model,
                   TravelledDistance = a.TravelledDistance,
                   Parts = a.Parts.Select(p => new PartModel
                   {
                       Name = p.Part.Name,
                       Price = p.Part.Price
                   })
               }).ToList();

            return carsParts;
        }
    }
}