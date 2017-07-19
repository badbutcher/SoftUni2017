namespace _005
{
    using System;
    using System.Collections.Generic;
    using _005.Interfaces;

    public class Program
    {
        public static void Main()
        {
            IList<ICitizen> citizens = new List<ICitizen>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }
                else
                {
                    string[] data = input.Split();

                    if (data.Length == 3)
                    {
                        citizens.Add(new Human(data[2], data[0], int.Parse(data[1])));
                    }
                    else if (data.Length == 2)
                    {
                        citizens.Add(new Robot(data[1], data[0]));
                    }
                }
            }

            string id = Console.ReadLine();
            foreach (var item in citizens)
            {
                if (item.Id.EndsWith(id))
                {
                    Console.WriteLine(item.Id);
                }
            }
        }
    }
}