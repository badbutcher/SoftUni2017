namespace _004
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            double[] input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            input.Select(a => a += a * 0.20)
                .ToList()
                .ForEach(a => Console.WriteLine("{0:F2}", a));
        }
    }
}