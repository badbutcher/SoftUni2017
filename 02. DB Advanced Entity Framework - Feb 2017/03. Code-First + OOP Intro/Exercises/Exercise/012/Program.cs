namespace _012
{
    using System;
    using System.Globalization;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            UserContext context = new UserContext();

            DateTime input = DateTime.Parse(Console.ReadLine());
            string formatted = input.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

            var result = context.Users
                .Where(d => d.IsDeleted == false);

            int counter = 0;
            foreach (var item in result)
            {
                if (item.LastTimeLoggedIn < DateTime.Parse(formatted))
                {
                    item.IsDeleted = true;
                    counter++;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("No users have been deleted");
            }
            else
            {
                Console.WriteLine(counter + " users have been deleted");
            }

            context.SaveChanges();
        }
    }
}