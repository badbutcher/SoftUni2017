namespace Car.Services.Implementastions
{
    using System.Collections.Generic;
    using System.Linq;
    using Car.Services.Models;
    using Cars.Data;
    using Cars.Data.Models;

    public class SupplierService : ISupplierService
    {
        private readonly CarDbContext db;

        public SupplierService(CarDbContext db)
        {
            this.db = db;
        }

        public void Add(string name, bool isImporter)
        {
            Supplier supplier = new Supplier()
            {
                Name = name,
                IsImporter = isImporter
            };

            this.db.Suppliers.Add(supplier);
            this.db.SaveChanges();
        }

        public IEnumerable<SupplierBasicInfoModel> All()
        {
            var result = this.db.Suppliers
                .Select(a => new SupplierBasicInfoModel
                {
                    Name = a.Name,
                    IsImporter = a.IsImporter
                });

            return result;
        }

        public void Delete(string name)
        {
            var result = this.db.Suppliers
                .FirstOrDefault(a => a.Name == name);

            this.db.Suppliers.Remove(result);
            this.db.SaveChanges();
        }

        public void Edit(string oldName, string newName, bool isImporter)
        {
            var supplier = this.db.Suppliers.FirstOrDefault(a => a.Name == oldName);

            supplier.Name = newName;
            supplier.IsImporter = isImporter;

            this.db.SaveChanges();
        }

        public SupplierBasicInfoModel GetSupplier(string name)
        {
            var suppler = this.db.Suppliers
                .Select(a => new SupplierBasicInfoModel
                {
                    Name = a.Name,
                    IsImporter = a.IsImporter
                })
                .FirstOrDefault(a => a.Name == name);

            return suppler;
        }

        public IEnumerable<SuppliersNameModel> GetSuppliers()
        {
            return this.db.Suppliers
                     .Select(a => new SuppliersNameModel
                     {
                         Name = a.Name
                     }).ToList();
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