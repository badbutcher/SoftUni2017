namespace _011
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            UserContext context = new UserContext();

            string pattern = Console.ReadLine();

            var result = context.Users
                .Where(u => u.Email.Substring(u.Email.Length - pattern.Length, pattern.Length) == pattern);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Username} {item.Email}");
            }
        }
    }
}