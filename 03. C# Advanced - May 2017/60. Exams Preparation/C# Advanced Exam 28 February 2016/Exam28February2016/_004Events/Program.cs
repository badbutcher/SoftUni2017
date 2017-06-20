namespace _004Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            SortedDictionary<string, SortedDictionary<string, List<DateTime>>> events = new SortedDictionary<string, SortedDictionary<string, List<DateTime>>>();
            string pattern = @"^#([A-Za-z]+):\s*@([A-Za-z]+)\s*?([012][0-9]:[012345][0-9])$";
            Regex regex = new Regex(pattern);

            DateTime dateTime;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string person = match.Groups[1].Value;
                    string location = match.Groups[2].Value;
                   
                    if (!events.ContainsKey(location))
                    {
                        events.Add(location, new SortedDictionary<string, List<DateTime>>());
                    }

                    if (!events[location].ContainsKey(person))
                    {
                        events[location].Add(person, new List<DateTime>());
                    }

                    if (DateTime.TryParse(match.Groups[3].Value, out dateTime))
                    {
                        events[location][person].Add(DateTime.Parse(match.Groups[3].Value));
                    }          
                }
            }

            string[] filter = Console.ReadLine().Split(',');

            foreach (var item in events.Where(a => filter.Contains(a.Key)))
            {
                Console.WriteLine(item.Key + ":");

                int counter = 1;

                foreach (var person in item.Value)
                {
                    var sortNumbers = person.Value.OrderBy(a => a).Select(c => c.ToString("HH:mm"));
                    Console.WriteLine("{0}. {1} -> {2}", counter++, person.Key, string.Join(", ", sortNumbers));
                }
            }
        }
    }
}