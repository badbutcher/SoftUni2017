namespace _011.Models
{
    using System;
    using System.Collections.Generic;

    public class Bet
    {
        public int Id { get; set; }

        public decimal BetMoneyAmount { get; set; }

        public DateTime TimeOfBet { get; set; }

        public User User { get; set; }

        public List<BetGame> Games { get; set; } = new List<BetGame>();
    }
}