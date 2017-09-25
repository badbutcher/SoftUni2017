namespace _010.Models
{
    using System;

    public class Bet
    {
        public int Id { get; set; }

        public decimal BetMoneyAmount { get; set; }

        public DateTime TimeOfBet { get; set; }

        public User User { get; set; }
    }
}