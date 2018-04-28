namespace _006
{
    using _006.Interfaces;
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            IList<IRobort> robots = new List<IRobort>();

            IList<IBirthdate> birthdates = new List<IBirthdate>();
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

                    if (data[0] == "Citizen")
                    {
                        birthdates.Add(new Human(data[3], data[1], int.Parse(data[2]), data[4]));
                    }
                    else if (data[0] == "Robot")
                    {
                        robots.Add(new Robot(data[2], data[1]));
                    }
                    else if (data[0] == "Pet")
                    {
                        birthdates.Add(new Pet(data[1], data[2]));
                    }
                }
            }

            string year = Console.ReadLine();

            foreach (var item in birthdates)
            {
                if (item.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(item.Birthdate);
                }
            }
        }
    }
}