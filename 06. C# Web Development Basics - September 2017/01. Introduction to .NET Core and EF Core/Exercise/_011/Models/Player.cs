using System.Collections.Generic;

namespace _011.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SqyadNumber { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public string PositionId { get; set; }

        public Position Position { get; set; }

        public bool IsInjured { get; set; }

        public List<PlayerStatistic> Statistics { get; set; } = new List<PlayerStatistic>();

        public List<PlayerGames> Games { get; set; } = new List<PlayerGames>();
    }
}