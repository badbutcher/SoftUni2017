namespace _001
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            char[] text = Console.ReadLine().ToArray();
            Array.Reverse(text);
            Console.WriteLine(text);
        }
    }
}