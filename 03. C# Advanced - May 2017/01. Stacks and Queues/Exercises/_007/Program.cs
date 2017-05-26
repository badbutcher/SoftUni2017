namespace _007
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Stack<char> openedParanthesis = new Stack<char>();
            char[] openingCases = new char[] { '{', '[', '(' };

            for (int i = 0; i < input.Length; i++)
            {
                if (openingCases.Contains(input[i]))
                {
                    openedParanthesis.Push(input[i]);
                }
                else
                {
                    if (openedParanthesis.Count() == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                    switch (input[i])
                    {
                        case '}':
                            if (openedParanthesis.Pop() != '{')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        case ']':
                            if (openedParanthesis.Pop() != '[')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        case ')':
                            if (openedParanthesis.Pop() != '(')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}