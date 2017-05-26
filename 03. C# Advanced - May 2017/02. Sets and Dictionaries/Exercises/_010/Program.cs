namespace _010
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, long>> populationDic = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "report")
                {
                    break;
                }
                else
                {
                    string city = input[0];
                    string country = input[1];
                    long population = long.Parse(input[2]);

                    if (!populationDic.ContainsKey(country))
                    {
                        populationDic.Add(country, new Dictionary<string, long>());
                        populationDic[country].Add(city, 0);
                    }

                    if (!populationDic[country].ContainsKey(city))
                    {
                        populationDic[country].Add(city, population);
                    }
                    else
                    {
                        populationDic[country][city] += population;
                    }
                }
            }

            var result = populationDic.OrderByDescending(a => a.Value.Values.Sum());

            foreach (var item in result)
            {
                Console.WriteLine("{0} (total population: {1})", item.Key, item.Value.Values.Sum());

                var orderCity = item.Value.OrderByDescending(a => a.Value);

                foreach (var inner in orderCity)
                {
                    Console.WriteLine("=>{0}: {1}", inner.Key, inner.Value);
                }
            }
        }
    }
}