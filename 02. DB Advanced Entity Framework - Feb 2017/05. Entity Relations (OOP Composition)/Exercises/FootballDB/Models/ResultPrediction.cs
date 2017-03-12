namespace FootballDB.Models
{
    using Enums;

    public class ResultPrediction
    {
        public int Id { get; set; }

        public PredictionType Prediction { get; set; }
    }
}