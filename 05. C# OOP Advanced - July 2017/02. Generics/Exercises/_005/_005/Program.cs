namespace _005
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Box<int> list = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                list.AddValue(input);
            }

            int[] reverseNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            list.Swap(reverseNumbers[0], reverseNumbers[1]);

            Console.WriteLine(list.ToString());
        }
    }
}