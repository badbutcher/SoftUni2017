using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001CollectResources
{
    class Program
    {
        static void Main()
        {
            string[] resources = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] path = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int start = path[0];
                int steps = path[1];

                for (int j = 0; j < resources.Length; j++)
                {
                    string[] item = resources[j].Split('_');
                    string resource = item[0];
                    int quantity = int.Parse(item[1]);

                    Console.WriteLine(resource);
                }
            }
        }
    }
}