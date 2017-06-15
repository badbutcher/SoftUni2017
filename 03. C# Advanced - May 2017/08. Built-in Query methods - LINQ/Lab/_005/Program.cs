namespace _005
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var result = input.Where(a => a % 2 == 0);
            if (result.Count() != 0)
            {
                Console.WriteLine("{0:F2}", result.Min());
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}