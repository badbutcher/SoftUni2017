namespace Car.Services.Implementastions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Car.Services.Models;
    using Cars.Data;
    using Cars.Data.Models;

    public class CustomerService : ICustomerService
    {
        private readonly CarDbContext db;

        public CustomerService(CarDbContext db)
        {
            this.db = db;
        }

        public void Add(string name, DateTime birthdate)
        {
            Customer customer = new Customer
            {
                Name = name,
                BirthDate = birthdate,
                IsYoungDriver = (DateTime.Now - birthdate).Days < 730 ? true : false
            };

            this.db.Add(customer);
            this.db.SaveChanges();
        }

        public CustomerCars CustomerCars(int id)
        {
            var result = this.db.Sales
                 .Where(a => a.CustomerId == id)
                 .Select(a => new CustomerCars
                 {
                     Name = a.Customer.Name,
                     CarsBought = a.Customer.Sales.Select(c => c.Id).Count(),
                     MoneySpend = a.Car.Parts.Sum(c => c.Part.Price)
                 }).FirstOrDefault();

            return result;
        }

        public void Edit(string oldName, string newName, DateTime birthdate)
        {
            Customer customer = this.db.Customers.FirstOrDefault(a => a.Name == oldName);

            customer.Name = newName;
            customer.BirthDate = birthdate;
            customer.IsYoungDriver = (DateTime.Now - birthdate).Days < 730 ? true : false;

            this.db.SaveChanges();
        }

        public IEnumerable<CustomerModel> OrderCustomers(OrderDirection order)
        {
            var custmoersQuery = this.db.Customers.AsQueryable();

            switch (order)
            {
                case OrderDirection.Ascending:
                    custmoersQuery = custmoersQuery.OrderBy(a => a.BirthDate).ThenBy(a => a.Name);
                    break;
                case OrderDirection.Descending:
                    custmoersQuery = custmoersQuery.OrderByDescending(a => a.BirthDate).ThenBy(a => a.Name);
                    break;
                default:
                    throw new InvalidOperationException("Invalid data");
            }

            return custmoersQuery
                .Select(a => new CustomerModel
                {
                    Name = a.Name,
                    BirthDate = a.BirthDate,
                    IsYoungDriver = a.IsYoungDriver
                }).ToList();
        }
    }
}