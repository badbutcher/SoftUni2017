namespace _002
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                int numOne = int.Parse(stack.Pop());
                char c = char.Parse(stack.Pop());
                int numTwo = int.Parse(stack.Pop());

                switch (c)
                {
                    case '+':
                        stack.Push((numOne + numTwo).ToString());
                        break;
                    case '-':
                        stack.Push((numOne - numTwo).ToString());
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}