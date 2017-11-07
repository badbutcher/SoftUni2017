namespace Car.Services.Implementastions
{
    using System.Collections.Generic;
    using System.Linq;
    using Car.Services.Models;
    using Cars.Data;
    using Cars.Data.Models;

    public class PartService : IPartService
    {
        private readonly CarDbContext db;

        public PartService(CarDbContext db)
        {
            this.db = db;
        }

        public void AddParts(string name, decimal price, int quantity, string supplier)
        {
            Part part = new Part
            {
                Name = name,
                Price = price,
                Quantity = quantity == 0 ? 1 : quantity,
                Supplier = this.db.Suppliers.FirstOrDefault(a => a.Name == supplier)
            };

            this.db.Parts.Add(part);
            this.db.SaveChanges();
        }

        public IEnumerable<PartModel> AllParts()
        {
            var result = this.db.Parts
                .Select(a => new PartModel
                {
                    Name = a.Name,
                    Price = a.Price,
                    Supplier = a.Supplier.Name,
                    Quantity = a.Quantity
                }).ToList();

            return result;
        }

        public void DeletePart(string name)
        {
            var part = this.db.Parts
                .FirstOrDefault(a => a.Name == name);

            if (part == null)
            {
                return;
            }

            this.db.Parts.Remove(part);
            this.db.SaveChanges();
        }

        public void Edit(string name, decimal price, int quantity)
        {
            var part = this.db.Parts.FirstOrDefault(a => a.Name == name);

            part.Price = price;
            part.Quantity = quantity;

            this.db.SaveChanges();
        }

        public PartModel GetPart(string name)
        {
            var part = this.db.Parts
                .Select(a => new PartModel
                {
                    Name = a.Name,
                    Price = a.Price,
                    Supplier = a.Supplier.Name,
                    Quantity = a.Quantity
                }).FirstOrDefault(a => a.Name == name);

            return part;
        }

        public List<PartCars> GetPartsByName(List<string> parts, string make, string model, long travelledDistance)
        {
            List<PartCars> result = new List<PartCars>();

            foreach (var name in parts)
            {
                PartCars partCar = new PartCars();
                Part part = this.db.Parts.FirstOrDefault(a => a.Name == name);
                Car car = this.db.Cars.FirstOrDefault(a => a.Make == make && a.Model == model);

                partCar.PartId = part.Id;
                partCar.Part = part;
                partCar.CarId = car.Id;
                partCar.Car = car;

                result.Add(partCar);
            }

            return result;
        }
    }
}