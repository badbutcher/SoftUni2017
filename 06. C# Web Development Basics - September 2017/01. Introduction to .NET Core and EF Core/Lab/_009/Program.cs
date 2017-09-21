namespace _009
{
    using System;
    using System.Linq;
    using _009.Models;
    using _009.Models.ManyToMany;

    public class Program
    {
        public static void Main()
        {
            using (var context = new MyDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                MakeSalesmen(context);
                MakeItems(context);
                Commands(context);

                int customerId = int.Parse(Console.ReadLine());
                var customer = context.Customers
                    .Where(a => a.Id == customerId && a.Orders.Count >= 1)
                    .Count();

                Console.WriteLine($"Orders:{customer}");
            }
        }

        private static void MakeItems(MyDbContext context)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                else
                {
                    string[] data = input.Split(';');
                    string name = data[0];
                    decimal price = decimal.Parse(data[1]);
                    Item item = new Item() { Name = name, Price = price };
                    context.Items.Add(item);
                }
            }

            context.SaveChanges();
        }

        private static void Commands(MyDbContext context)
        {
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
        }

        private static void ReviewCommand(MyDbContext context, string args)
        {
            var parts = args.Split(';');
            int customerId = int.Parse(parts[0]);
            int itemId = int.Parse(parts[1]);

            var review = new Review { CustomerId = customerId, ItemId = itemId };

            context.Reviews.Add(review);
            context.SaveChanges();
        }

        private static void OrderCommand(MyDbContext context, string args)
        {
            var parts = args.Split(';');
            int customerId = int.Parse(parts[0]);

            var order = new Order { CustomerId = customerId };

            for (int i = 1; i < parts.Length; i++)
            {
                var itemId = int.Parse(parts[i]);
                order.Items.Add(new ItemOrder { ItemId = itemId });
            }

            context.Orders.Add(order);
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