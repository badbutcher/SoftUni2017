namespace _005
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string rankOne = Console.ReadLine();
            string suitOne = Console.ReadLine();
            string rankTwo = Console.ReadLine();
            string suitTwo = Console.ReadLine();

            Card cardOne = new Card((CardRanks)Enum.Parse(typeof(CardRanks), rankOne), (CardSuits)Enum.Parse(typeof(CardSuits), suitOne));
            Card cardTwo = new Card((CardRanks)Enum.Parse(typeof(CardRanks), rankTwo), (CardSuits)Enum.Parse(typeof(CardSuits), suitTwo));
            if (cardOne.CompareTo(cardTwo) > 0)
            {
                Console.WriteLine(cardOne.ToString());
            }
            else
            {
                Console.WriteLine(cardTwo.ToString());
            }
        }
    }
}