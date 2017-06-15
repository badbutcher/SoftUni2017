namespace _008
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Array.Sort(input, Compare);
            Console.WriteLine(string.Join(" ", input));
        }

        private static int Compare(int a, int b)
        {
            if (Math.Abs(a) % 2 == 0 && Math.Abs(b) % 2 == 1)
            {
                return -1;
            }
            else if (Math.Abs(a) % 2 == 1 && Math.Abs(b) % 2 == 0)
            {
                return 1;
            }

            return a.CompareTo(b);
        }
    }
}