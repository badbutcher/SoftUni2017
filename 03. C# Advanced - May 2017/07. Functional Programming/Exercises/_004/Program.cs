namespace _004
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string type = Console.ReadLine().Trim().ToLower();
            Predicate<string> typeCheck = x => x == "odd";

            Predicate<int> numbers;

            if (typeCheck(type))
            {
                numbers = x => x % 2 == 1;
            }
            else
            {
                numbers = x => x % 2 == 0;
            }

            List<int> result = new List<int>();

            for (int i = input[0]; i <= input[1]; i++)
            {
                if (numbers(i))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}