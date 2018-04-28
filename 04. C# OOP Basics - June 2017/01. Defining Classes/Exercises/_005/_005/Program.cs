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
            int result = mod.DifferenceInDates(dateOne, dateTwo);
            Console.WriteLine(result);
        }
    }
}