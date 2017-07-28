using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008
{
    public class Program
    {
        public static void Main()
        {
            List<Card> cards = new List<Card>();

            foreach (CardSuits suit in Enum.GetValues(typeof(CardSuits)))
            {
                foreach (CardRanks rank in Enum.GetValues(typeof(CardRanks)))
                {
                    Card card = new Card(rank, suit);
                    cards.Add(card);
                }
            }

            string playerOne = Console.ReadLine();
            string playerTwo = Console.ReadLine();
            List<Card> playerOneCards = new List<Card>();
            List<Card> playerTwoCards = new List<Card>();

            while (playerOneCards.Count < 5 && playerTwoCards.Count < 5)
            {
                string[] cardInfo = Console.ReadLine().Split();
                CardRanks cardRank;
                CardSuits cardSuit;
                
                if (!(Enum.TryParse(cardInfo[0], out cardRank)))
                {
                    Console.WriteLine("No such card exists");
                    continue;
                }

                if (!(Enum.TryParse(cardInfo[2], out cardSuit)))
                {
                    Console.WriteLine("No such card exists");
                    continue;
                }

                Card card = new Card(cardRank, cardSuit);
                if (cards.Any(c => c.Equals(card)))
                {

                }
            }
        }
    }
}