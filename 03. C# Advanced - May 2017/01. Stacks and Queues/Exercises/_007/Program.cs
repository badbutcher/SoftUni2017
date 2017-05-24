using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (currentChar == '(')
                {
                    stack.Push(i);
                }
                else if (currentChar == ')')
                {
                    int start = stack.Pop();
                    Console.WriteLine(input.Substring(start, i - start + 1));
                }
            }

            Console.WriteLine();
        }
    }
}