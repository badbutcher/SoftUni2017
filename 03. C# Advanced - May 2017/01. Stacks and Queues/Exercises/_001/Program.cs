namespace _001
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> result = new Stack<int>(n);

            for (int i = 0; i < n.Length; i++)
            {
                Console.Write(result.Pop() + " ");
            }
        }
    }
}