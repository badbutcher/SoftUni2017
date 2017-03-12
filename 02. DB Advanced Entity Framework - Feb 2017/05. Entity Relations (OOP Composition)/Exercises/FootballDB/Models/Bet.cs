namespace FootballDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Bet
    {
        public Bet()
        {
            this.BetGames = new HashSet<BetGame>();
        }

        public int Id { get; set; }

        public decimal BetMoneyAmount { get; set; }

        public DateTime TimeOfBet { get; set; }

        public User User { get; set; }

        [InverseProperty("Bet")]
        public virtual ICollection<BetGame> BetGames { get; set; }
    }
}