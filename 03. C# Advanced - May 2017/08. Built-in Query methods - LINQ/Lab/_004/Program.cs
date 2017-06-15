namespace _004
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var result = input.Average();
            Console.WriteLine("{0:F2}", result);
        }
    }
}