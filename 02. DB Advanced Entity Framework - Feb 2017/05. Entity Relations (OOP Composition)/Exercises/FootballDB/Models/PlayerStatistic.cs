namespace FootballDB.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PlayerStatistic
    {
        [Key]
        [Column(Order = 0)]
        public int GameId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int PlayerId { get; set; }

        public Game Game { get; set; }

        public Player Player { get; set; }

        public int ScoredGoals { get; set; }

        public int PlayerAssists { get; set; }

        public int TimePlayed { get; set; }
    }
}