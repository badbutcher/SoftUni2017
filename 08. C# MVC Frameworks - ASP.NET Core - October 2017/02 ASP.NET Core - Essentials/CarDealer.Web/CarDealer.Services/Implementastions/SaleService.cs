namespace CarDealer.Services.Implementastions
{
    using System.Collections.Generic;
    using System.Linq;
    using CarDealer.Data;
    using CarDealer.Services.Models.Cars;
    using CarDealer.Services.Models.Sales;

    public class SaleService : ISaleService
    {
        private readonly CarDealerDbContext db;

        public SaleService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SaleListModel> All()
        {
            var result = this.db.Sales
                .OrderByDescending(p => p.Id)
                .Select(a => new SaleListModel
                {
                    Id = a.Id,
                    CustomerName = a.Customer.Name,
                    Discount = a.Discount,
                    IsYoungDriver = a.Customer.IsYoungDriver,
                    Price = a.Car.Parts.Sum(c => c.Part.Price)
                }).ToList();

            return result;
        }

        public SaleDetailModel Details(int id)
        {
            var result = this.db.Sales
                .Where(s => s.Id == id)
                .Select(a => new SaleDetailModel
                {
                    Id = a.Id,
                    CustomerName = a.Customer.Name,
                    Discount = a.Discount,
                    IsYoungDriver = a.Customer.IsYoungDriver,
                    Price = a.Car.Parts.Sum(c => c.Part.Price),
                    Car = new CarModel
                    {
                        Make = a.Car.Make,
                        Model = a.Car.Model,
                        TravelledDistance = a.Car.TravelledDistance
                    }
                }).FirstOrDefault();

            return result;
        }
    }
}