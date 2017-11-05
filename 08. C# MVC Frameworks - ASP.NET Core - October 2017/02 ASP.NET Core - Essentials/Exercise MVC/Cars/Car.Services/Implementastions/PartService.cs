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
                    Supplier = a.Supplier.Name
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

        public PartModel GetPart(string name)
        {
            var part = this.db.Parts
                .Select(a => new PartModel
                {
                    Name = a.Name,
                    Price = a.Price,
                    Supplier = a.Supplier.Name
                }).FirstOrDefault(a => a.Name == name);

            return part;
        }
    }
}