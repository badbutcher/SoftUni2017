namespace _004
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            SortedDictionary<string, List<double>> result = new SortedDictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double[] grades = Console.ReadLine().Trim().Split().Select(double.Parse).ToArray();

                if (!result.ContainsKey(name))
                {
                    result.Add(name, new List<double>());
                }

                for (int j = 0; j < grades.Length; j++)
                {
                    result[name].Add(grades[j]);
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine("{0} is graduated with {1}", item.Key, item.Value.Average());
            }
        }
    }
}