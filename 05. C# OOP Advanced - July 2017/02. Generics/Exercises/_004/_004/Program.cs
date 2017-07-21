namespace _004
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> list = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                list.AddValue(input);
            }

            int[] reverseNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            list.Swap(reverseNumbers[0], reverseNumbers[1]);

            Console.WriteLine(list.ToString());
        }
    }
}