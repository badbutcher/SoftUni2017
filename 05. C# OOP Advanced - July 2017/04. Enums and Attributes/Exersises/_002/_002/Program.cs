namespace _002
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Card Ranks:");
            foreach (var item in Enum.GetValues(typeof(CardRanks)))
            {
                Console.WriteLine($"Ordinal value: {(int)item}; Name value: {item}");
            }
        }
    }
}