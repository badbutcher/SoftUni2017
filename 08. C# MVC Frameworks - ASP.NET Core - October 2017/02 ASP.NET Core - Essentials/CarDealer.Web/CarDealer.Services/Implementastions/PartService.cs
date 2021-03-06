﻿namespace CarDealer.Services.Implementastions
{
    using System.Collections.Generic;
    using System.Linq;
    using CarDealer.Data;
    using CarDealer.Data.Models;
    using CarDealer.Services.Models.Parts;

    public class PartService : IPartService
    {
        private readonly CarDealerDbContext db;

        public PartService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<PartBasicModel> All()
        {
            var result = this.db.Parts
                .OrderBy(a => a.Id)
                .Select(a => new PartBasicModel
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList();

            return result;
        }

        public IEnumerable<PartListingModel> AllListings(int page = 1, int pageSize = 25)
        {
            var result = this.db.Parts
                .OrderByDescending(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new PartListingModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierName = p.Supplier.Name
                }).ToList();

            return result;
        }

        public PartDetailsModel ById(int id)
        {
            var result = this.db.Parts
                .Where(a => a.Id == id)
                .Select(a => new PartDetailsModel
                {
                    Name = a.Name,
                    Price = a.Price,
                    Quantity = a.Quantity
                }).FirstOrDefault();

            return result;
        }

        public void Create(string name, decimal price, int quantity, int supplierId)
        {
            var part = new Part
            {
                Name = name,
                Price = price,
                Quantity = quantity > 0 ? quantity : 1,
                SupplierId = supplierId
            };

            this.db.Parts.Add(part);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var part = this.db.Parts.Find(id);

            if (part == null)
            {
                return;
            }

            this.db.Parts.Remove(part);
            this.db.SaveChanges();
        }

        public void Edit(int id, decimal price, int quantity)
        {
            var part = this.db.Parts.Find(id);

            if (part == null)
            {
                return;
            }

            part.Price = price;
            part.Quantity = quantity;

            this.db.SaveChanges();
        }

        public int Total()
        {
            var result = this.db.Parts.Count();

            return result;
        }
    }
}