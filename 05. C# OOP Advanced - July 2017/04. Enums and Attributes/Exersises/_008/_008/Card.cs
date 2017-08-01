namespace _008
{
    using System;

    public class Card : IComparable<Card>
    {
        public Card(string rank, string suit)
        {
            this.Rank = (CardRanks)Enum.Parse(typeof(CardRanks), rank);
            this.Suit = (CardSuits)Enum.Parse(typeof(CardSuits), suit);
        }

        public CardRanks Rank { get; set; }

        public CardSuits Suit { get; set; }

        public int Power
        {
            get { return (int)this.Rank + (int)this.Suit; }
        }

        public string Name
        {
            get { return this.Rank + " of " + this.Suit; }
        }

        public int CompareTo(Card other)
        {
            //if (this.Power.CompareTo(other.Power) > 0)
            //{
            //    return this.Power.CompareTo(other.Power);
            //}

            //if (this.Power.CompareTo(other.Power) < 0)
            //{
            //    return this.Power.CompareTo(other.Power);
            //}

            //return 0;

            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (ReferenceEquals(null, other))
            {
                return 1;
            }

            var rankComparion = this.Suit.CompareTo(other.Suit);

            if (rankComparion != 0)
            {
                return rankComparion;
            }

            return this.Rank.CompareTo(other.Rank);
        }

        public override string ToString()
        {
            return $"Card name: {this.Name}; Card power: {this.Power}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Card card = obj as Card;
            return this.Power.Equals(card.Power);
        }
    }
}