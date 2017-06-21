namespace _004AshesofRoses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string pattern = @"^Grow\s<([A-Z][a-z]+)>\s<([A-Za-z0-9]+)>\s([0-9]+)$";
            Regex regex = new Regex(pattern);
            Dictionary<string, Dictionary<string, decimal>> roses = new Dictionary<string, Dictionary<string, decimal>>();
            
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Icarus, Ignite!")
                {
                    break;
                }
                else
                {
                    Match match = regex.Match(input);

                    if (match.Success)
                    {
                        string region = match.Groups[1].Value;
                        string color = match.Groups[2].Value;
                        int amount = int.Parse(match.Groups[3].Value);

                        if (!roses.ContainsKey(region))
                        {
                            roses.Add(region, new Dictionary<string, decimal>());
                        }

                        if (!roses[region].ContainsKey(color))
                        {
                            roses[region].Add(color, 0);
                        }

                        roses[region][color] += amount;
                    }
                }
            }

            var result = roses.OrderByDescending(a => a.Value.Values.Sum()).ThenBy(c => c.Key);

            foreach (var r in result)
            {
                Console.WriteLine(r.Key);

                var sort = r.Value.OrderBy(a => a.Value).ThenBy(c => c.Key);
                foreach (var c in sort)
                {
                    Console.WriteLine("*--{0} | {1}", c.Key, c.Value);
                }
            }
        }
    }
}