namespace _006
{
    using System;
    using System.Linq;
    using _006.Models;

    public class Program
    {
        public static void Main()
        {
            using (var context = new MyDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                MakeSalesmen(context);

                while (true)
                {
                    string input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }
                    else
                    {
                        string[] data = input.Split('-');
                        string command = data[0];

                        switch (command)
                        {
                            case "register":
                                RegisterCommand(context, data[1]);
                                break;
                            case "order":
                                OrderCommand(context, data[1]);
                                break;
                            case "review":
                                ReviewCommand(context, data[1]);
                                break;
                            default:
                                break;
                        }
                    }
                }

                var sort = context.Customers
                    .Select(a => new
                    {
                        Name = a.Name,
                        Orders = a.Orders.Count,
                        Reviews = a.Reviews.Count
                    })
                    .OrderByDescending(a => a.Orders)
                    .ThenByDescending(a => a.Reviews)
                    .ToList();

                foreach (var customer in sort)
                {
                    Console.WriteLine(customer.Name);
                    Console.WriteLine($"Orders:{customer.Orders}");
                    Console.WriteLine($"Reviews:{customer.Reviews}");
                }
            }
        }

        private static void ReviewCommand(MyDbContext context, string id)
        {
            int customerId = int.Parse(id);
            Customer customer = context.Customers.FirstOrDefault(a => a.Id == customerId);
            customer.Reviews.Add(new Review { CustomerId = customerId });
            context.SaveChanges();
        }

        private static void OrderCommand(MyDbContext context, string id)
        {
            int customerId = int.Parse(id);
            Customer customer = context.Customers.FirstOrDefault(a => a.Id == customerId);
            customer.Orders.Add(new Order { CustomerId = customerId });
            context.SaveChanges();
        }

        private static void RegisterCommand(MyDbContext context, string data)
        {
            string[] customerInfo = data.Split(';');
            string name = customerInfo[0];
            int id = int.Parse(customerInfo[1]);
            Customer customer = new Customer() { Name = name, SalesmanId = id };
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        private static void MakeSalesmen(MyDbContext context)
        {
            string[] salesmans = Console.ReadLine().Split(';');

            foreach (var name in salesmans)
            {
                Salesman salesman = new Salesman() { Name = name };
                context.Salesmans.Add(salesman);
            }

            context.SaveChanges();
        }
    }
}