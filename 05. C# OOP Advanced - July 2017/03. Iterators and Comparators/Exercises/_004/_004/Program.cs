namespace _004
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Lake lake = new Lake(input.ToList());

            List<int> stones = new List<int>();
            foreach (var item in lake)
            {
                stones.Add(item);
            }

            Console.WriteLine(string.Join(", ", stones));
        }
    }
}