namespace _007
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Box<double> list = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                list.AddValue(input);
            }

            double itemToCompare = double.Parse(Console.ReadLine());

            int count = list.Compare(itemToCompare);

            Console.WriteLine(count);
        }
    }
}