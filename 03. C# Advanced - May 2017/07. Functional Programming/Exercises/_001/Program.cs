namespace _001
{
    using System;

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();

            Action<string> print = a => Console.WriteLine(a);

            foreach (var item in input)
            {
                print(item);
            }
        }
    }
}