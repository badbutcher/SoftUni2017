namespace _001
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Card Suits:");
            foreach (var item in Enum.GetValues(typeof(CardSuits)))
            {
                Console.WriteLine($"Ordinal value: {(int)item}; Name value: {item}");
            }
        }
    }
}