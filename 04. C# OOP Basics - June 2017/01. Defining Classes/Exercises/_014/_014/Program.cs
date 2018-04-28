namespace _014
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<Cat> cats = new List<Cat>();

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
                    string type = data[0];
                    string name = data[1];

                    if (type == "Siamese")
                    {
                        cats.Add(new Siamese(type, name, int.Parse(data[2])));
                    }
                    else if (type == "Cymric")
                    {
                        cats.Add(new Cymric(type, name, decimal.Parse(data[2])));
                    }
                    else if (type == "StreetExtraordinaire")
                    {
                        cats.Add(new StreetExtraordinaire(type, name, int.Parse(data[2])));
                    }
                }
            }

            string findCat = Console.ReadLine();
            Cat result = cats.First(a => a.Name == findCat);
            Console.WriteLine(result.ToString());
        }
    }
}