namespace _002
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();

            input.Select(a => a.ToUpper())
                .ToList()
                .ForEach(c => Console.Write(c + " "));
        }
    }
}