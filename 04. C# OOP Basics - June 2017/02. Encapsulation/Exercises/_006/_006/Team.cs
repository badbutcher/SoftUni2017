using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006
{
    public class Team
    {
        private string name;
        private decimal rating;
        private List<Player> players;

        public Team(string name, decimal rating, List<Player> players)
        {
            this.Name = name;
            this.Rating = rating;
            this.Players = players;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public decimal Rating
        {
            get
            {
                return this.rating;
            }
            set
            {
                this.rating = value;
            }
        }

        public List<Player> Players
        {
            get
            {
                return this.players;
            }
            set
            {
                this.players = value;
            }
        }

        public double GetRating()
        {
            double rating = 0;
            int playersCount = Players.Count;

            if (playersCount != 0)
            {
                foreach (var item in players)
                {
                    rating += item.Rating();
                }

                rating = Math.Ceiling(rating / playersCount);
            }

            return rating;
        }
    }
}