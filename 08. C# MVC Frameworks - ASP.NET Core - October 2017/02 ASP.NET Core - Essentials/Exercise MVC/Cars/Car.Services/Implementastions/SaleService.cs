namespace Car.Services.Implementastions
{
    using System.Collections.Generic;
    using System.Linq;
    using Car.Services.Models;
    using Cars.Data;
    using Cars.Data.Models;

    public class SaleService : ISaleService
    {
        private readonly CarDbContext db;

        public SaleService(CarDbContext db)
        {
            this.db = db;
        }

        public void Add(Customer customer, Car car, decimal discount)
        {
            Sale sale = new Sale
            {
                Customer = customer,
                Car = car,
                Discount = discount
            };

            this.db.Sales.Add(sale);
            this.db.SaveChanges();
        }

        public IEnumerable<SalesModel> AllSales()
        {
            var result = this.db.Sales
                .Select(a => new SalesModel
                {
                    Make = a.Car.Make,
                    Model = a.Car.Model,
                    TravlledDistance = a.Car.TravelledDistance,
                    CustomerName = a.Customer.Name,
                    Price = a.Car.Parts.Sum(c => c.Part.Price),
                    PriceWithSale = a.Car.Parts.Sum(c => c.Part.Price) * a.Discount
                }).ToList();

            return result;
        }

        public IEnumerable<SalesModel> SaleById(int id)
        {
            var result = this.db.Sales
                .Where(a => a.Id == id)
                .Select(a => new SalesModel
                {
                    Make = a.Car.Make,
                    Model = a.Car.Model,
                    TravlledDistance = a.Car.TravelledDistance,
                    CustomerName = a.Customer.Name,
                    Price = a.Car.Parts.Sum(c => c.Part.Price),
                    PriceWithSale = a.Car.Parts.Sum(c => c.Part.Price) * a.Discount
                }).ToList();

            return result;
        }

        public IEnumerable<SalesModel> SaleWithDiscount()
        {
            var result = this.db.Sales
                .Where(a => a.Discount > 0)
                .Select(a => new SalesModel
                {
                    Make = a.Car.Make,
                    Model = a.Car.Model,
                    TravlledDistance = a.Car.TravelledDistance,
                    CustomerName = a.Customer.Name,
                    Price = a.Car.Parts.Sum(c => c.Part.Price),
                    PriceWithSale = a.Car.Parts.Sum(c => c.Part.Price) * a.Discount
                }).ToList();

            return result;
        }

        public IEnumerable<SalesModel> SaleWithGivenDiscount(decimal number)
        {
            var result = this.db.Sales
                .Where(a => a.Discount > number)
                .Select(a => new SalesModel
                {
                    Make = a.Car.Make,
                    Model = a.Car.Model,
                    TravlledDistance = a.Car.TravelledDistance,
                    CustomerName = a.Customer.Name,
                    Price = a.Car.Parts.Sum(c => c.Part.Price),
                    PriceWithSale = a.Car.Parts.Sum(c => c.Part.Price) * a.Discount
                }).ToList();

            return result;
        }
    }
}