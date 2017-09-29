namespace _001
{
    using System;
    using System.Linq;
    using System.Threading;

    public class Program
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Thread thread = new Thread(() => PrintNumber(input[0], input[1]));
            thread.Start();
            thread.Join();

            Console.WriteLine("Thread finished work");
        }

        private static void PrintNumber(int min, int max)
        {
            for (int i = min; i <= max; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}