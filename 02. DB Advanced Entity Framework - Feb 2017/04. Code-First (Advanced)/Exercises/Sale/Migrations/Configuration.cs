namespace Sale.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Sale.SaleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            AutomaticMigrationDataLossAllowed = true;

            ContextKey = "Sale.SaleContext";
        }

        protected override void Seed(Sale.SaleContext context)
        {
            Product p1 = new Product
            {
                Name = "Apple",
                Price = 10.00m,
                Quantity = 10.0d
            };

            Product p2 = new Product
            {
                Name = "Orange",
                Price = 5.00m,
                Quantity = 1.0d
            };

            Product p3 = new Product
            {
                Name = "Banana",
                Price = 20.00m,
                Quantity = 5.0d
            };

            Product p4 = new Product
            {
                Name = "Watermelon",
                Price = 100.00m,
                Quantity = 1.0d
            };

            Product p5 = new Product
            {
                Name = "Kivi",
                Price = 120.00m,
                Quantity = 50.0d
            };

            Customer c1 = new Customer
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                CreditCardNumber = "123456789"
            };

            Customer c2 = new Customer
            {
                FirstName = "Gosho",
                LastName = "Peshov",
                CreditCardNumber = "635423ref"
            };

            Customer c3 = new Customer
            {
                FirstName = "Tosho",
                LastName = "Peshov",
                CreditCardNumber = "cvxbdgrt4"
            };

            Customer c4 = new Customer
            {
                FirstName = "Pavel",
                LastName = "Peshov",
                CreditCardNumber = "czdsefwtregdf"
            };

            Customer c5 = new Customer
            {
                FirstName = "Zakom",
                LastName = "Peshov",
                CreditCardNumber = "wq3r4tergfv"
            };

            StoreLocation sl1 = new StoreLocation
            {
                LocationName = "Sofia"
            };

            StoreLocation sl2 = new StoreLocation
            {
                LocationName = "Varna"
            };

            StoreLocation sl3 = new StoreLocation
            {
                LocationName = "Ruse"
            };

            StoreLocation sl4 = new StoreLocation
            {
                LocationName = "London"
            };

            StoreLocation sl5 = new StoreLocation
            {
                LocationName = "Madrid"
            };

            _Sale s1 = new _Sale
            {
                Product = p1,
                Customer = c1,
                StoreLocation = sl1,
                Date = DateTime.Now
            };

            _Sale s2 = new _Sale
            {
                Product = p2,
                Customer = c2,
                StoreLocation = sl2,
                Date = DateTime.Now
            };

            _Sale s3 = new _Sale
            {
                Product = p2,
                Customer = c2,
                StoreLocation = sl2,
                Date = DateTime.Now
            };

            _Sale s4 = new _Sale
            {
                Product = p4,
                Customer = c3,
                StoreLocation = sl1,
                Date = DateTime.Now
            };

            _Sale s5 = new _Sale
            {
                Product = p5,
                Customer = c3,
                StoreLocation = sl4,
                Date = DateTime.Now
            };

            context.Sales.Add(s1);
            context.Sales.Add(s2);
            context.Sales.Add(s3);
            context.Sales.Add(s4);
            context.Sales.Add(s5);

            context.SaveChanges();
        }
    }
}
