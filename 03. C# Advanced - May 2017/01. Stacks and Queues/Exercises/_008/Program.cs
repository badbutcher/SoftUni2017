namespace _008
{
    using System;

    class Program
    {
        private static long[] fibNumbers;

        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            fibNumbers = new long[n];
            long result = GetFibunacci(n);
            Console.WriteLine(result);
        }

        private static long GetFibunacci(long n)
        {
            if (n <= 2)
            {
                return 1;
            }

            if (fibNumbers[n-1] != 0)
            {
                return fibNumbers[n - 1];
            }

            return fibNumbers[n-1] = GetFibunacci(n - 1) + GetFibunacci(n - 2);
        }
    }
}