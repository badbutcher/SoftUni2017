namespace _009
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<long> result = new Stack<long>();

            result.Push(0);
            result.Push(1);

            for (int i = 0; i < n; i++)
            {
                long a = result.Pop();
                long b = result.Pop();
                long c = a + b;
                result.Push(a);
                result.Push(c);
            }

            result.Pop();
            Console.WriteLine(result.Peek());
        }
    }
}