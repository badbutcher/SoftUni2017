namespace _006
{
    using System;

    public class Player
    {
        private string name;
        private Stats stats;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public Stats Stats
        {
            get
            {
                return this.stats;
            }
            private set
            {
                this.stats = value;
            }
        }

        public double Rating()
        {
            double rating = Math.Round((stats.Dribble + stats.Endurance + stats.Passing + stats.Shooting + stats.Sprint) / 5.0);

            return rating;
        }
    }
}