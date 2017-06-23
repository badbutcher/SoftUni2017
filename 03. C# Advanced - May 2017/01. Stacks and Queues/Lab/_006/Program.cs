namespace _006
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            Queue<string> result = new Queue<string>(input);
            int count = 1;
            while (result.Count != 1)
            {
                for (int i = 1; i < n; i++)
                {
                    result.Enqueue(result.Dequeue());
                }

                if (IsPrime(count))
                {
                    Console.WriteLine($"Prime {result.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {result.Dequeue()}");
                }

                count++;
            }

            Console.WriteLine($"Last is {result.Dequeue()}");
        }

        private static bool IsPrime(int number)
        {
            if (number == 1)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}