namespace Car.Services.Implementastions
{
    using System.Collections.Generic;
    using System.Linq;
    using Car.Services.Models;
    using Cars.Data;

    public class SupplierService : ISupplierService
    {
        private readonly CarDbContext db;

        public SupplierService(CarDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SupplierModel> Supplier(string type)
        {
            if (type == "local")
            {
                return this.db.Suppliers
                     .Where(a => a.IsImporter == false)
                     .Select(a => new SupplierModel
                     {
                         Id = a.Id,
                         Name = a.Name,
                         NumberOfParts = a.Parts.Count
                     }).ToList();
            }
            else
            {
                return this.db.Suppliers
                   .Where(a => a.IsImporter == true)
                   .Select(a => new SupplierModel
                   {
                       Id = a.Id,
                       Name = a.Name,
                       NumberOfParts = a.Parts.Count
                   }).ToList();
            }
        }
    }
}