namespace _011.Models
{
    using System;
    using System.Collections.Generic;

    public class Game
    {
        public int Id { get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime DateTimeOfGame { get; set; }

        public float HomeTeamBetRate { get; set; }

        public float AwayTeamBetRate { get; set; }

        public float DrawGameBetRate { get; set; }

        public Round Round { get; set; }

        public Competition Competition { get; set; }

        public List<BetGame> Bets { get; set; } = new List<BetGame>();

        public List<PlayerStatistic> PlayersStatistics { get; set; } = new List<PlayerStatistic>();

        public List<PlayerGames> PlayersGames { get; set; } = new List<PlayerGames>();
    }
}