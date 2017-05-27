namespace _011
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<int> poisons = Console.ReadLine().Split().Select(int.Parse).ToList();

            int counter = 0;
            while (true)
            {
                Stack<int> stillAlive = new Stack<int>();
                Stack<int> died = new Stack<int>();
                stillAlive.Push(0);

                for (int i = 1; i < poisons.Count; i++)
                {
                    int left = poisons[i - 1];
                    int right = poisons[i];
                    if (left >= right)
                    {
                        stillAlive.Push(i);
                    }
                    else
                    {
                        died.Push(i);
                    }
                }

                if (died.Count == 0)
                {
                    break;
                }
                else
                {
                    while (died.Count != 0)
                    {
                        poisons.RemoveAt(died.Pop());
                    }

                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}