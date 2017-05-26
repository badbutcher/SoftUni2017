using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> mine = new Dictionary<string, int>();

            while (true)
            {
                string resource = Console.ReadLine();

                if (resource == "stop")
                {
                    break;
                }
                else
                {
                    int quantity = int.Parse(Console.ReadLine());

                    if (!mine.ContainsKey(resource))
                    {
                        mine.Add(resource, quantity);
                    }
                    else
                    {
                        mine[resource] += quantity;
                    }
                }
            }

            foreach (var item in mine)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
    }
}