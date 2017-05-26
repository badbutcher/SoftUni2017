namespace _003
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            double[] input = Console.ReadLine().Trim().Split(' ').Select(double.Parse).ToArray();
            SortedDictionary<double, int> result = new SortedDictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                double number = input[i];
                if (!result.ContainsKey(number))
                {
                    result.Add(number, 0);
                }

                result[number]++;
            }

            foreach (var item in result)
            {
                Console.WriteLine("{0} - {1} times", item.Key, item.Value);
            }
        }
    }
}