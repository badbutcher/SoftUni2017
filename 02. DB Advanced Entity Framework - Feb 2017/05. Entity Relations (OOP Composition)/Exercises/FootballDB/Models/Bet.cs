namespace FootballDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Bet
    {
        public Bet()
        {
            //this.Games = new HashSet<Game>();
            this.BetGames = new HashSet<BetGame>();
        }

        public int Id { get; set; }

        public decimal BetMoneyAmount { get; set; }

        public DateTime TimeOfBet { get; set; }


        public User User { get; set; }

        //public virtual ICollection<Game> Games { get; set; }

        public virtual ICollection<BetGame> BetGames { get; set; }
    }
}