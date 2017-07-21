namespace _001
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var value = Console.ReadLine();
            Box<string> box = new Box<string>(value);
            Console.WriteLine(box.ToString());
        }
    }
}