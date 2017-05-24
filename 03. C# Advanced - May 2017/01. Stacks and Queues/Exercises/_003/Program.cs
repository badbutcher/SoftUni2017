namespace _003
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> result = new Stack<int>();
            Stack<int> maxNumbers = new Stack<int>();
            int maxValue = 0;

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int cmd = input[0];

                if (cmd == 1)
                {
                    int data = input[1];
                    result.Push(data);
                    if (maxValue < data)
                    {
                        maxValue = data;
                        maxNumbers.Push(maxValue);
                    }
                }
                else
                {
                    switch (cmd)
                    {
                        case 2:
                            if (result.Pop() == maxValue)
                            {
                                maxNumbers.Pop();
                                if (maxNumbers.Count() != 0)
                                {
                                    maxValue = maxNumbers.Peek();
                                }
                                else
                                {
                                    maxValue = 0;
                                }
                            }
                            break;
                        case 3:
                            Console.WriteLine(maxValue);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}