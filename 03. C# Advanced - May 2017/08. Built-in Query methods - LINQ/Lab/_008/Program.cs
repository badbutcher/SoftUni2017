namespace _008
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Trim().Split();
            long minPopulation = long.Parse(Console.ReadLine());
            Dictionary<string, List<long>> map = new Dictionary<string, List<long>>();

            foreach (var item in input)
            {
                string[] split = item.Split(':');
                string city = split[0];
                long pop = long.Parse(split[1]);

                if (!map.ContainsKey(city))
                {
                    map.Add(city, new List<long>());
                }

                map[city].Add(pop);
            }

            var result = map.Where(a => a.Value.Sum() > minPopulation)
                .OrderByDescending(c => c.Value.Sum());

            foreach (var item in result)
            {
                Console.WriteLine("{0}: {1}", item.Key, string.Join(" ", item.Value.OrderByDescending(c => c).Take(5)));
            }
        }
    }
}