namespace _005
{
    using System;
    using System.Linq;
    using _005.Models;

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
                            default:
                                break;
                        }
                    }
                }

                var sort = context.Salesmans
                    .Select(a => new
                    {
                        Name = a.Name,
                        Customers = a.Customers.Count
                    })
                    .OrderByDescending(a => a.Customers)
                    .ThenBy(a => a.Name)
                    .ToList();

                foreach (var item in sort)
                {
                    Console.WriteLine($"{item.Name} - {item.Customers} customers");
                }
            }
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