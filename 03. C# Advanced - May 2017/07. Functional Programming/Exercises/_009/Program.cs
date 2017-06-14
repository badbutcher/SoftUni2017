namespace _009
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int end = int.Parse(Console.ReadLine());
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            Func<List<int>, int, List<int>> res = Dividers;

            Console.WriteLine(string.Join(" ", res(numbers, end)));
        }

        private static List<int> Dividers(List<int> numbers, int end)
        {
            List<int> result = new List<int>();

            bool canDiv = true;
            for (int i = 1; i <= end; i++)
            {
                canDiv = true;
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (i % numbers[j] != 0)
                    {
                        canDiv = false;
                        break;
                    }
                }

                if (canDiv)
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}