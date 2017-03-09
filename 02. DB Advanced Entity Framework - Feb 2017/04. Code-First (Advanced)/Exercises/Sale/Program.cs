namespace Sale
{
    using Sale.Models;

    class Program
    {
        static void Main()
        {
            SaleContext context = new SaleContext();

            Product test = new Product();
            test.Name = "test";
            test.Description = "test";
            context.Products.Add(test);
            context.SaveChanges();

            //Product p1 = new Product
            //{
            //    Name = "Apple",
            //    Price = 10.00m,
            //    Quantity = 10.0d
            //};

            //Product p2 = new Product
            //{
            //    Name = "Orange",
            //    Price = 5.00m,
            //    Quantity = 1.0d
            //};

            //Product p3 = new Product
            //{
            //    Name = "Banana",
            //    Price = 20.00m,
            //    Quantity = 5.0d
            //};

            //Product p4 = new Product
            //{
            //    Name = "Watermelon",
            //    Price = 100.00m,
            //    Quantity = 1.0d
            //};

            //Product p5 = new Product
            //{
            //    Name = "Kivi",
            //    Price = 120.00m,
            //    Quantity = 50.0d
            //};

            //Customer c1 = new Customer
            //{
            //    Name = "Pesho",
            //    CreditCardNumber = "123456789"
            //};

            //Customer c2 = new Customer
            //{
            //    Name = "Gosho",
            //    CreditCardNumber = "635423ref"
            //};

            //Customer c3 = new Customer
            //{
            //    Name = "Tosho",
            //    CreditCardNumber = "cvxbdgrt4"
            //};

            //Customer c4 = new Customer
            //{
            //    Name = "Pavel",
            //    CreditCardNumber = "czdsefwtregdf"
            //};

            //Customer c5 = new Customer
            //{
            //    Name = "Zakom",
            //    CreditCardNumber = "wq3r4tergfv"
            //};

            //StoreLocation sl1 = new StoreLocation
            //{
            //    LocationName = "Sofia"
            //};

            //StoreLocation sl2 = new StoreLocation
            //{
            //    LocationName = "Varna"
            //};

            //StoreLocation sl3 = new StoreLocation
            //{
            //    LocationName = "Ruse"
            //};

            //StoreLocation sl4 = new StoreLocation
            //{
            //    LocationName = "London"
            //};

            //StoreLocation sl5 = new StoreLocation
            //{
            //    LocationName = "Madrid"
            //};

            //_Sale s1 = new _Sale
            //{
            //    Product = p1,
            //    Customer = c1,
            //    StoreLocation = sl1,
            //    Date = DateTime.Now
            //};

            //_Sale s2 = new _Sale
            //{
            //    Product = p2,
            //    Customer = c2,
            //    StoreLocation = sl2,
            //    Date = DateTime.Now
            //};

            //_Sale s3 = new _Sale
            //{
            //    Product = p2,
            //    Customer = c2,
            //    StoreLocation = sl2,
            //    Date = DateTime.Now
            //};

            //_Sale s4 = new _Sale
            //{
            //    Product = p4,
            //    Customer = c3,
            //    StoreLocation = sl1,
            //    Date = DateTime.Now
            //};

            //_Sale s5 = new _Sale
            //{
            //    Product = p5,
            //    Customer = c3,
            //    StoreLocation = sl4,
            //    Date = DateTime.Now
            //};

            //context.Sales.Add(s1);
            //context.Sales.Add(s2);
            //context.Sales.Add(s3);
            //context.Sales.Add(s4);
            //context.Sales.Add(s5);

            //context.SaveChanges();
        }
    }
}