namespace _004CubicAssault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, long>> cubic = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Count em all")
                {
                    break;
                }
                else
                {
                    string[] data = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                    string regionName = data[0];
                    string meteorType = data[1];
                    long count = long.Parse(data[2]);

                    if (!cubic.ContainsKey(regionName))
                    {
                        cubic.Add(regionName, new Dictionary<string, long>());
                        cubic[regionName].Add("Green", 0);
                        cubic[regionName].Add("Red", 0);
                        cubic[regionName].Add("Black", 0);
                    }

                    cubic[regionName][meteorType] += count;

                    if (cubic[regionName]["Green"] >= 1000000)
                    {
                        cubic[regionName]["Red"] += cubic[regionName]["Green"] / 1000000;
                        cubic[regionName]["Green"] = cubic[regionName]["Green"] % 1000000;
                    }

                    if (cubic[regionName]["Red"] >= 1000000)
                    {
                        cubic[regionName]["Black"] += cubic[regionName]["Red"] / 1000000;
                        cubic[regionName]["Red"] = cubic[regionName]["Red"] % 1000000;
                    }
                }
            }

            var result = cubic.OrderByDescending(a => a.Value["Black"]).ThenBy(c => c.Key.Length).ThenBy(q => q.Key);

            foreach (var region in result)
            {
                Console.WriteLine(region.Key);

                var sort = region.Value.OrderByDescending(a => a.Value).ThenBy(c => c.Key);
                foreach (var meteor in sort)
                {
                    Console.WriteLine("-> {0} : {1}", meteor.Key, meteor.Value);
                }
            }
        }
    }
}