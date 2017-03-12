namespace FootballDB.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PlayerStatistic
    {
        public int Id { get; set; }

        //[Key]
        //[Column(Order = 0)]
        public Game Game { get; set; }

        //[Key]
        //[Column(Order = 1)]
        public Player Player { get; set; }

        public int ScoredGoals { get; set; }

        public int PlayerAssists { get; set; }

        public int TimePlayed { get; set; }
    }
}