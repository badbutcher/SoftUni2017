namespace _010.Models
{
    using System;

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
    }
}