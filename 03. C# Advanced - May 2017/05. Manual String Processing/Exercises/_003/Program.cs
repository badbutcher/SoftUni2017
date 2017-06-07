namespace _003
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            double[] numbers = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            int a = (int)numbers[0];
            double b = numbers[1];
            double c = numbers[2];
            string binary = Convert.ToString(a, 2).PadLeft(10, '0');
            if (binary.Length > 10)
            {
                binary = binary.Substring(0, 10);
            }

            Console.WriteLine("|{0,-10:X}|{1}|{2,10:F2}|{3,-10:F3}|", a, binary, b, c);
        }
    }
}