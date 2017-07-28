namespace _007
{
    using System;

    public class Program
    {
        public static void Main()
        {
            foreach (var suit in Enum.GetValues(typeof(CardSuits)))
            {
                foreach (var rank in Enum.GetValues(typeof(CardRanks)))
                {
                    Console.WriteLine($"{rank} of {suit}");
                }
            }
        }
    }
}