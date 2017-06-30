using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012
{
    public class Program
    {
        public static void Main()
        {
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
                    string name = data[0];

                    if (data[1] == "company")
                    {
                        string companyName = data[2];
                        string department = data[3];
                        decimal salary = decimal.Parse(data[4]);
                    }
                    else if (data[1] == "pokemon")
                    {
                        string pokemonName = data[2];
                        string pokemonType = data[3];
                    }
                    else if (data[1] == "parents")
                    {
                        string parentName = data[2];
                        DateTime parentBirthday = DateTime.Parse(data[3]);
                    }
                    else if (data[1] == "children")
                    {
                        string childName = data[2];
                        DateTime childBirthday = DateTime.Parse(data[3]);
                    }
                    else if (data[1] == "car")
                    {
                        string carModel = data[2];
                        int carSpeed = int.Parse(data[3]);
                    }
                }
            }

            string search = Console.ReadLine();
        }
    }
}