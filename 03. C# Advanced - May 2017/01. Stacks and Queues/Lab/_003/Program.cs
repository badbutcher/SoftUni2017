namespace _003
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            if (input == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (input != 0)
                {
                    stack.Push(input % 2);
                    input /= 2;
                }

                while (stack.Count != 0)
                {
                    Console.Write(stack.Pop());
                }
            }
        }
    }
}