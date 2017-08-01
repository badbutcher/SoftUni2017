using System;
using System.Collections.Generic;

namespace _008
{
    public class Program
    {
        private static Card biggest;
        private static string winner;

        public static void Main()
        {
            Game();
        }

        private static void Game()
        {
            List<Card> deck = GenerateDeck();

            string firstPlayer = Console.ReadLine();
            string secondPlayer = Console.ReadLine();
            List<Card> firstDeck = new List<Card>();
            List<Card> secondDeck = new List<Card>();

            while (firstDeck.Count < 5 || secondDeck.Count < 5)
            {
                var inputArgs = Console.ReadLine().Split();
                try
                {
                    var card = new Card(inputArgs[0], inputArgs[inputArgs.Length - 1]);
                    if (deck.Contains(card))
                    {
                        deck.Remove(card);
                        if (firstDeck.Count < 5)
                        {
                            firstDeck.Add(card);
                            WinnerCheck(card, firstPlayer);
                        }
                        else
                        {
                            secondDeck.Add(card);
                            WinnerCheck(card, secondPlayer);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Card is not in the deck.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("No such card exists.");
                }
            }

            Console.WriteLine($"{winner} wins with {biggest.Name}.");
        }

        public static void WinnerCheck(Card card, string player)
        {
            if (card.CompareTo(biggest) > 0)
            {
                biggest = card;
                winner = player;
            }
        }

        public static List<Card> GenerateDeck()
        {
            List<Card> deck = new List<Card>();

            foreach (var suit in Enum.GetNames(typeof(CardSuits)))
            {
                foreach (var rank in Enum.GetNames(typeof(CardRanks)))
                {
                    deck.Add(new Card(rank, suit));
                }
            }

            return deck;
        }
    }
}