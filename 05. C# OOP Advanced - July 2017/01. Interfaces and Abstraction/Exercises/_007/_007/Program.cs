namespace _007
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _007.Interfaces;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            //Fix
            IDictionary<string, ICitizen> people = new Dictionary<string, ICitizen>();
            IDictionary<string, IRebel> rebels = new Dictionary<string, IRebel>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                if (data.Length == 4)
                {
                    if (!people.ContainsKey(data[0]) && !rebels.ContainsKey(data[0]))
                    {
                        people.Add(data[0], new Human(data[0], int.Parse(data[1]), data[2], data[3]));
                    }
                }
                else if (data.Length == 3)
                {
                    if (!people.ContainsKey(data[0]) && !rebels.ContainsKey(data[0]))
                    {
                        rebels.Add(data[0], new Rebel(data[0], int.Parse(data[1]), data[2]));
                    }
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }
                else
                {
                    if (people.ContainsKey(input))
                    {
                        people[input].BuyFood();
                    }
                    else if (rebels.ContainsKey(input))
                    {
                        rebels[input].BuyFood();
                    }
                }
            }

            Console.WriteLine(people.Sum(a => a.Value.Food) + rebels.Sum(c => c.Value.Food));
        }
    }
}