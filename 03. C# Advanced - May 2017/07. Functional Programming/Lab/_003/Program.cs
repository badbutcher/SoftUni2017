namespace _003
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> check = a => a[0] == a.ToUpper()[0];

            input.Where(check)
                .ToList()
                .ForEach(a => Console.WriteLine(a));
        }
    }
}