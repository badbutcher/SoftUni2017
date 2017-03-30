namespace CarDealer.App
{
    using System;

    using Data;
    using Models;
    using System.Xml.Linq;
    using System.Linq;

    public class Application
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

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
            _06_5(context);
            ////_06_6(context);
        }

        private static void _06_6(CarDealerContext context)
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

            XDocument document = new XDocument();
            XElement xml = new XElement("sales");

            foreach (var item in result)
            {
                XElement sale = new XElement("sale");
                XElement car = new XElement("car");
                car.SetAttributeValue("make", item.Car.Make);
                car.SetAttributeValue("model", item.Car.Model);
                car.SetAttributeValue("travelled-distance", item.Car.TravelledDistance);

                XElement customer = new XElement("customer-name");
                customer.Value = item.Name;

                XElement discount = new XElement("discount");
                discount.Value = item.Discount.ToString();

                XElement price = new XElement("price");
                price.Value = item.Price.ToString();

                XElement priceDiscount = new XElement("price-with-discount");
                priceDiscount.Value = item.PriceDiscound.ToString();

                sale.Add(car);
                sale.Add(customer);
                sale.Add(discount);
                sale.Add(price);
                sale.Add(priceDiscount);

                xml.Add(sale);
            }

            document.Add(xml);
            document.Save("../../_06_6.xml");
        }

        private static void _06_5(CarDealerContext context)
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

            XDocument document = new XDocument();
            XElement xml = new XElement("customers");

            foreach (var item in result)
            {
                XElement customer = new XElement("customer");
                customer.SetAttributeValue("full-name", item.FullName);
                customer.SetAttributeValue("bought-cars", item.BoughtCars);
                customer.SetAttributeValue("spent-money", item.SpendMoney);

                xml.Add(customer);
            }

            document.Add(xml);
            document.Save("../../_06_5.xml");
        }

        private static void _06_4(CarDealerContext context)
        {
            var result = context.Cars
                .Select(c => new
                {
                    c.Make,
                    c.Model,
                    c.TravelledDistance,
                    Parts = c.Parts
                    .Select(p => new
                    {
                        p.Name,
                        p.Price
                    })
                })
                .ToList();

            XDocument document = new XDocument();
            XElement xml = new XElement("cars");

            foreach (var item in result)
            {
                XElement car = new XElement("car");
                car.SetAttributeValue("make", item.Make);
                car.SetAttributeValue("model", item.Model);
                car.SetAttributeValue("travelled-distance", item.TravelledDistance);

                xml.Add(car);

                XElement parts = new XElement("parts");

                foreach (var part in item.Parts)
                {
                    XElement carPart = new XElement("part");
                    carPart.SetAttributeValue("name", part.Name);
                    carPart.SetAttributeValue("price", part.Price);

                    parts.Add(carPart);
                }

                xml.Add(parts);
            }

            document.Add(xml);
            document.Save("../../_06_4.xml");
        }

        private static void _06_3(CarDealerContext context)
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

            XDocument document = new XDocument();
            XElement xml = new XElement("suppliers");

            foreach (var item in result)
            {
                XElement suplier = new XElement("suplier");
                suplier.SetAttributeValue("id", item.Id);
                suplier.SetAttributeValue("name", item.Name);
                suplier.SetAttributeValue("parts-count", item.PartsCount);

                xml.Add(suplier);
            }

            document.Add(xml);
            document.Save("../../_06_3.xml");
        }

        private static void _06_2(CarDealerContext context)
        {
            var result = context.Cars
                .Where(t => t.Make == "Ferrari")
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

            XDocument document = new XDocument();
            XElement xml = new XElement("cars");

            foreach (var item in result)
            {
                XElement car = new XElement("car");
                car.SetAttributeValue("id", item.Id);
                car.SetAttributeValue("model", item.Model);
                car.SetAttributeValue("travelled-distance", item.TravelledDistance);

                xml.Add(car);
            }

            document.Add(xml);
            document.Save("../../_06_2.xml");
        }

        private static void _06_1(CarDealerContext context)
        {
            var result = context.Cars
                  .Where(d => d.TravelledDistance > 2000000)
                  .OrderBy(o => o.Model);
            XDocument document = new XDocument();
            XElement xml = new XElement("cars");

            foreach (var item in result)
            {
                XElement car = new XElement("car");
                car.SetElementValue("make", item.Make);
                car.SetElementValue("model", item.Model);
                car.SetElementValue("travelled-distance", item.TravelledDistance);

                xml.Add(car);
            }

            document.Add(xml);
            document.Save("../../_06_1.xml");
        }

        private static void AddSales(CarDealerContext context)
        {
            decimal[] discounts = new decimal[] { 0m, 0.05m, 0.10m, 0.20m, 0.30m, 0.40m, 0.50m };
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
                    rndDiscount += 0.05m;
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

        private static void AddCustomers(CarDealerContext context)
        {
            XDocument document = XDocument.Load("../../Xmls/customers.xml");
            XElement root = document.Root;

            foreach (var item in root.Elements())
            {
                string customerName = item.Attribute("name").Value;
                DateTime birthDate = DateTime.Parse(item.Element("birth-date").Value);
                bool isYoungDriver = bool.Parse(item.Element("is-young-driver").Value);
                Customer customer = new Customer()
                {
                    Name = customerName,
                    BirthDate = birthDate,
                    IsYoungDriver = isYoungDriver
                };

                context.Customers.Add(customer);
            }

            context.SaveChanges();
        }

        private static void AddCars(CarDealerContext context)
        {
            XDocument document = XDocument.Load("../../Xmls/cars.xml");
            XElement root = document.Root;
            Random rndItem = new Random();
            int partsCount = context.Parts.Count();
            foreach (var item in root.Elements())
            {
                string make = item.Element("make").Value;
                string model = item.Element("model").Value;
                long travelledDistance = long.Parse(item.Element("travelled-distance").Value);
                Car car = new Car()
                {
                    Make = make,
                    Model = model,
                    TravelledDistance = travelledDistance,
                };

                context.Cars.Add(car);
                for (int i = 0; i < rndItem.Next(11, 21); i++)
                {
                    Part part = context.Parts.Find(rndItem.Next(1, partsCount + 1));
                    car.Parts.Add(part);
                }
            }

            context.SaveChanges();
        }

        private static void AddParts(CarDealerContext context)
        {
            XDocument document = XDocument.Load("../../Xmls/parts.xml");
            XElement root = document.Root;
            Random rndItem = new Random();
            foreach (var item in root.Elements())
            {
                string name = item.Attribute("name").Value;
                decimal price = decimal.Parse(item.Attribute("price").Value);
                int quantity = int.Parse(item.Attribute("quantity").Value);

                Part part = new Part()
                {
                    Name = name,
                    Price = price,
                    Quantity = quantity,
                    SupplierId = rndItem.Next(1, context.Suppliers.Count() + 1)
                };

                context.Parts.Add(part);
            }

            context.SaveChanges();
        }

        private static void AddSuppliers(CarDealerContext context)
        {
            XDocument document = XDocument.Load("../../Xmls/suppliers.xml");
            XElement root = document.Root;

            foreach (var item in root.Elements())
            {
                string name = item.Attribute("name").Value;
                bool import = bool.Parse(item.Attribute("is-importer").Value);

                Supplier supplier = new Supplier()
                {
                    Name = name,
                    IsImporter = import
                };

                context.Suppliers.Add(supplier);
            }

            context.SaveChanges();
        }
    }
}
