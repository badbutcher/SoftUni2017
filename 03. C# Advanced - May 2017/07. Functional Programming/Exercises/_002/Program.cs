namespace _002
{
    using System;

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> printSir = a => Console.WriteLine("Sir {0}", a);

            foreach (var item in input)
            {
                printSir(item);
            }
        }
    }
}