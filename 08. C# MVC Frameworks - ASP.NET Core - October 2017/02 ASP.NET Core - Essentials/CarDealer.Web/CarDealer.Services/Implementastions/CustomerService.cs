namespace CarDealer.Services.Implementastions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarDealer.Data;
    using CarDealer.Data.Models;
    using CarDealer.Services.Models.Customers;
    using CarDealer.Services.Models.Enums;
    using CarDealer.Services.Models.Sales;

    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CustomerService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public CustomerModel ById(int id)
        {
            var result = this.db.Customers
                .Where(c => c.Id == id)
                .Select(c => new CustomerModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    BirthDay = c.BirthDay,
                    IsYoungDriver = c.IsYoungDriver
                }).FirstOrDefault();

            return result;
        }

        public void Create(string name, DateTime birthday, bool isYoungDriver)
        {
            var customer = new Customer
            {
                Name = name,
                BirthDay = birthday,
                IsYoungDriver = isYoungDriver
            };

            this.db.Add(customer);
            this.db.SaveChanges();
        }

        public void Edit(int id, string name, DateTime birthDay, bool isYoungDriver)
        {
            var existingCustomers = this.db.Customers.Find(id);

            if (existingCustomers == null)
            {
                return;
            }

            existingCustomers.Name = name;
            existingCustomers.BirthDay = birthDay;
            existingCustomers.IsYoungDriver = isYoungDriver;

            this.db.SaveChanges();
        }

        public bool Exists(int id)
        {
            var result = this.db.Customers.Any(a => a.Id == id);

            return result;
        }

        public IEnumerable<CustomerModel> Ordered(OrderDirection order)
        {
            var customerQuery = this.db.Customers.AsQueryable();

            switch (order)
            {
                case OrderDirection.Ascending:
                    customerQuery = customerQuery.OrderBy(c => c.BirthDay).ThenBy(c => c.Name);
                    break;
                case OrderDirection.Descending:
                    customerQuery = customerQuery.OrderByDescending(c => c.BirthDay).ThenBy(c => c.Name);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid order direction: {order}.");
            }

            return customerQuery
                .Select(c => new CustomerModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    BirthDay = c.BirthDay,
                    IsYoungDriver = c.IsYoungDriver
                }).ToList();
        }

        public CustomersTotalSalesModel TotalSalesById(int id)
        {
            var result = this.db.Customers
                 .Where(a => a.Id == id)
                 .Select(a => new CustomersTotalSalesModel
                 {
                     Name = a.Name,
                     IsYoungDriver = a.IsYoungDriver,
                     BoughtCars = a.Sales.Select(s => new SaleModel
                     {
                         Price = s.Car.Parts.Sum(p => p.Part.Price),
                         Discount = s.Discount
                     })
                 }).FirstOrDefault();

            return result;
        }
    }
}