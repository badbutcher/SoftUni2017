namespace _010.Models
{
    public class PlayerStatistic
    {
        public Game Game { get; set; }

        public Player Player { get; set; }

        public int ScoredGoals { get; set; }

        public int PlayerAssists { get; set; }

        public int TimePlayed { get; set; }
    }
}