namespace _006
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int divider = int.Parse(Console.ReadLine());

            Predicate<int> numbers = x => x % divider != 0;

            List<int> remove = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (numbers(input[i]))
                {
                    remove.Add(input[i]);
                }
            }

            Func<List<int>, List<int>> rev = ReverseNumber;
            remove = rev(remove);

            Console.WriteLine(string.Join(" ", remove));
        }

        private static List<int> ReverseNumber(List<int> arg)
        {
            List<int> result = new List<int>();

            for (int i = arg.Count - 1; i >= 0; i--)
            {
                result.Add(arg[i]);
            }

            return result;
        }
    }
}