namespace _003
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string[] names = Console.ReadLine().Split();

            string[] letters = Console.ReadLine().Split().OrderBy(a => a).ToArray();
            string result = string.Empty;
            foreach (var item in letters)
            {
                result = names
                .Where(a => a.ToLower()
                .StartsWith(item.ToLower()))
                .FirstOrDefault();
                if (result != null)
                {
                    Console.WriteLine(result);
                    break;
                }
            }

            if (result == null)
            {
                Console.WriteLine("No match");
            }
        }
    }
}