namespace _013
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string command = Console.ReadLine();

            var srubsko = new Dictionary<string, Dictionary<string, int>>();

            while (command != "End")
            {
                string[] input = Regex.Split(command, @"([A-Za-z\s]+)\s+@([A-Za-z\s]+)\s+([0-9]+)\s+([0-9]+)");
                if (input.Length >= 6)
                {
                    string singer = input[1];
                    string venue = input[2];
                    int ticketsPrice = int.Parse(input[3]);
                    int ticketsCount = int.Parse(input[4]);

                    if (!srubsko.ContainsKey(venue))
                    {
                        srubsko.Add(venue, new Dictionary<string, int>());
                    }

                    if (!srubsko[venue].ContainsKey(singer))
                    {
                        srubsko[venue].Add(singer, 0);
                    }

                    srubsko[venue][singer] += ticketsCount * ticketsPrice;
                }

                command = Console.ReadLine();
            }

            foreach (var srub in srubsko)
            {
                Console.WriteLine("{0}", srub.Key);
                var sorter = srub.Value.OrderByDescending(x => x.Value);

                foreach (var sort in sorter)
                {
                    Console.WriteLine("#  {0} -> {1}", sort.Key, sort.Value);
                }
            }
        }
    }
}