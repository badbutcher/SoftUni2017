namespace _001
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            input.Distinct()
                .Where(a => a >= 10 && a <= 20)
                .Take(2)
                .ToList()
                .ForEach(c => Console.Write(c + " "));
        }
    }
}