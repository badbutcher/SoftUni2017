namespace _004
{
    public class Card
    {
        public Card(CardRanks rank, CardSuits suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public CardRanks Rank { get; private set; }

        public CardSuits Suit { get; private set; }

        private int GetPower()
        {
            return (int)this.Rank + (int)this.Suit;
        }

        public override string ToString()
        {
            return $"Card name: {this.Rank} of {this.Suit}; Card power: {GetPower()}";
        }
    }
}