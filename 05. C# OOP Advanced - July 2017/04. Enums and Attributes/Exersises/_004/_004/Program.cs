namespace _004
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string rank = Console.ReadLine();
            string suit = Console.ReadLine();
            Card card = new Card((CardRanks)Enum.Parse(typeof(CardRanks), rank), (CardSuits)Enum.Parse(typeof(CardSuits), suit));
            Console.WriteLine(card.ToString());
        }
    }
}