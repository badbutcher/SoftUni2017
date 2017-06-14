namespace _003
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> check = CheckMin;

            Console.WriteLine(check(input));
        }

        private static int CheckMin(int[] input)
        {
            int min = int.MaxValue;

            foreach (var item in input)
            {
                if (item < min)
                {
                    min = item;
                }
            }

            return min;
        }
    }
}