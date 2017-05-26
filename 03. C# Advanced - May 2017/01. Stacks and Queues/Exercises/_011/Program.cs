using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _011
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<int> posions = Console.ReadLine().Split().Select(int.Parse).ToList();
               
            List<int> indexToRemove = new List<int>();
            int counter = 0;
            while (true)
            {
                for (int i = 1; i < posions.Count; i++)
                {
                    int left = posions[i - 1];
                    int right = posions[i];
                    if (right >= left && right != -100)
                    {
                        indexToRemove.Add(i);
                    }
                }

                if (indexToRemove.Count == 0)
                {
                    break;
                }
                else
                {
                    for (int i = 0; i < indexToRemove.Count; i++)
                    {
                        posions.RemoveAt(indexToRemove[i]);
                        posions.Insert(indexToRemove[i],-100);
                    }

                    indexToRemove.Clear();
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}