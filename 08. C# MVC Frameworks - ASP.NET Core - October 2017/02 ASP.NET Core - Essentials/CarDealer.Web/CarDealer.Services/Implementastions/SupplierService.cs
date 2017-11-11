namespace CarDealer.Services.Implementastions
{
    using System.Collections.Generic;
    using System.Linq;
    using CarDealer.Data;
    using CarDealer.Services.Models.Suppliers;

    public class SupplierService : ISupplierService
    {
        private readonly CarDealerDbContext db;

        public SupplierService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SupplierModel> All()
        {
            var result = this.db.Suppliers
                .OrderBy(a => a.Name)
                .Select(s => new SupplierModel
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList();

            return result;
        }

        public IEnumerable<SupplierListingModel> AllListings(bool isImporter)
        {
            var suppler = this.db.Suppliers
                .OrderByDescending(p => p.Id)
                .Where(s => s.IsImporter == isImporter)
                .Select(s => new SupplierListingModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    TotalParts = s.Parts.Count
                }).ToList();

            return suppler;
        }
    }
}