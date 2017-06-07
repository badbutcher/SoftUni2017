namespace _002
{
    using System;

    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            text = text.PadRight(20, '*');
            Console.WriteLine(text.Substring(0,20));
        }
    }
}