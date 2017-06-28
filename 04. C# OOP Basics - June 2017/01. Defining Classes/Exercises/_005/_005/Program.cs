namespace _005
{
    using System;

    public class Program
    {
        public static void Main()
        {
            DateTime dateOne = DateTime.Parse(Console.ReadLine());
            DateTime dateTwo = DateTime.Parse(Console.ReadLine());

            DateModifier mod = new DateModifier();

            Console.WriteLine(mod.DifferenceInDates(dateOne, dateTwo));
        }
    }
}