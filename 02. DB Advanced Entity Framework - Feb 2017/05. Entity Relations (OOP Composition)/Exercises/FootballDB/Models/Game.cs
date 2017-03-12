namespace FootballDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        public Game()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
            this.BetGames = new HashSet<BetGame>();
        }

        [Key]
        public int Id { get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        [Range(0, int.MaxValue)]
        public int HomeGoals { get; set; }

        [Range(0, int.MaxValue)]
        public int AwayGoals { get; set; }

        public DateTime DateTimeOfGame { get; set; }

        [Range(0, int.MaxValue)]
        public float HomeTeamBetRate { get; set; }

        [Range(0, int.MaxValue)]
        public float AwayTeamBetRate { get; set; }

        [Range(0, int.MaxValue)]
        public float DrawGameBetRate { get; set; }

        public Round Round { get; set; }

        public Competition Competition { get; set; }

        [InverseProperty("Game")]
        public virtual ICollection<BetGame> BetGames { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}