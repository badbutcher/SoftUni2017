namespace _005
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

            while (result.Count != 1)
            {
                for (int i = 1; i < n; i++)
                {
                    result.Enqueue(result.Dequeue());
                }

                Console.WriteLine($"Removed {result.Dequeue()}");
            }

            Console.WriteLine($"Last is {result.Dequeue()}");
        }
    }
}