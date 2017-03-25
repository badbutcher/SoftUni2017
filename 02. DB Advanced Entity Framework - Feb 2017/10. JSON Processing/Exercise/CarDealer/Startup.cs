using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer
{
    class Startup
    {
        static void Main()
        {
            CarContext context = new CarContext();
            ////context.Database.Initialize(true);

            ////05
            ////AddSuppliers(context);
            ////AddParts(context);
            ////AddCars(context);
            ////AddCustomers(context);
            ////AddSales(context);

            ////_06_1(context);
            ////_06_2(context);
            ////_06_3(context);
            ////_06_4(context);
            ////_06_5(context);
            ////_06_6(context);

        }

        private static void _06_6(CarContext context)
        {
            var result = context.Sales
                .Select(c => new
                {
                    Car = new { c.Car.Make, c.Car.Model, c.Car.TravelledDistance },
                    c.Customer.Name,
                    c.Discount,
                    Price = c.Car.Parts.Sum(s => s.Price),
                    PriceDiscound = (c.Car.Parts.Sum(p => p.Price)) - (c.Car.Parts.Sum(p => p.Price) * c.Discount)

                })
                .ToList();

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);

            File.WriteAllText("../../Exports/[6.6].json", json);
        }

        private static void _06_5(CarContext context)
        {
            var result = context.Customers
                .Where(s => s.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Sum(s => s.Car.Id),
                    SpendMoney = c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price))
                })
                .OrderByDescending(c => c.SpendMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);

            File.WriteAllText("../../Exports/[6.5].json", json);
        }

        private static void _06_4(CarContext context)
        {
            var result = context.Cars
                .Select(c => new
                {
                    c.Make,
                    c.Model,
                    c.TravelledDistance,
                    Part = c.Parts
                    .Select(p => new
                    {
                        p.Name,
                        p.Price
                    })
                })
                .ToList();

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);

            File.WriteAllText("../../Exports/[6.4].json", json);
        }

        private static void _06_3(CarContext context)
        {
            var result = context.Suppliers
                .Where(i => i.IsImporter == false)
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    PartsCount = c.Parts.Count
                })
                .ToList();

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);

            File.WriteAllText("../../Exports/[6.3].json", json);
        }

        private static void _06_2(CarContext context)
        {
            var result = context.Cars
                .Where(t => t.Make == "Toyota")
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .OrderBy(b => b.Model)
                .ThenByDescending(b => b.TravelledDistance)
                .ToList();

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);

            File.WriteAllText("../../Exports/[6.2].json", json);
        }

        private static void _06_1(CarContext context)
        {
            var result = context.Customers
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.BirthDate,
                    c.IsYoungDriver,
                    c.Sales.Count////Tova mo gurmi 
                })
                .OrderBy(b => b.BirthDate)
                .ThenByDescending(b => b.IsYoungDriver)
                .ToList();

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);

            File.WriteAllText("../../Exports/[6.1].json", json);
        }

        private static void AddSales(CarContext context)
        {
            float[] discounts = new float[] { 0f, 0.05f, 0.10f, 0.20f, 0.30f, 0.40f, 0.50f };
            Random rndItem = new Random();
            var cars = context.Cars.ToList();
            var customers = context.Customers.ToList();

            foreach (var item in customers)
            {
                var rndCar = cars[rndItem.Next(cars.Count)];
                var rndCustomer = customers[rndItem.Next(customers.Count)];
                var rndDiscount = discounts[rndItem.Next(discounts.Length)];

                if (rndCustomer.IsYoungDriver)
                {
                    rndDiscount += 0.05f;
                }

                Sale sale = new Sale()
                {
                    Car = rndCar,
                    Customer = rndCustomer,
                    Discount = rndDiscount
                };

                context.Sales.Add(sale);
            }

            context.SaveChanges();
        }

        private static void AddCustomers(CarContext context)
        {
            string jsonString = File.ReadAllText("../../Jsons/customers.json");
            var json = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
            context.Customers.AddRange(json);
            context.SaveChanges();
        }

        private static void AddCars(CarContext context)
        {
            string jsonString = File.ReadAllText("../../Jsons/cars.json");
            var json = JsonConvert.DeserializeObject<List<Car>>(jsonString);
            int partsCount = context.Parts.Count();
            Random rndItem = new Random();
            foreach (var item in json)
            {
                for (int i = 0; i < rndItem.Next(11, 21); i++)
                {
                    Part part = context.Parts.Find(rndItem.Next(1, partsCount + 1));
                    item.Parts.Add(part);
                }
            }

            context.Cars.AddRange(json);
            context.SaveChanges();
        }

        private static void AddParts(CarContext context)
        {
            string jsonString = File.ReadAllText("../../Jsons/parts.json");
            var json = JsonConvert.DeserializeObject<List<Part>>(jsonString);
            Random rndItem = new Random();
            foreach (var item in json)
            {
                item.SupplierId = rndItem.Next(1, context.Suppliers.Count() + 1);
            }

            context.Parts.AddRange(json);
            context.SaveChanges();
        }

        private static void AddSuppliers(CarContext context)
        {
            string jsonString = File.ReadAllText("../../Jsons/suppliers.json");
            var json = JsonConvert.DeserializeObject<List<Supplier>>(jsonString);
            context.Suppliers.AddRange(json);
            context.SaveChanges();
        }
    }
}
