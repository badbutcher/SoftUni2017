namespace _001
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var result = input
                .Where(a => a % 2 == 0)
                .OrderBy(a => a);

            Console.WriteLine(string.Join(", ", result));
        }
    }
}