namespace _007
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] startEnd = Console.ReadLine().Split().Select(int.Parse).OrderBy(a => a).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            numbers.Where(a => a >= startEnd[0] && a <= startEnd[1])
                .ToList()
                .ForEach(c => Console.Write(c + " "));
        }
    }
}