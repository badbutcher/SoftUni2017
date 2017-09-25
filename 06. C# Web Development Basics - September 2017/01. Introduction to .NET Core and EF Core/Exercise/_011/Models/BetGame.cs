namespace _011.Models
{
    public class BetGame
    {
        public int GameId { get; set; }

        public Game Game { get; set; }

        public int BetId { get; set; }

        public Bet Bet { get; set; }

        public ResultPrediction ResultPrediction { get; set; }
    }
}