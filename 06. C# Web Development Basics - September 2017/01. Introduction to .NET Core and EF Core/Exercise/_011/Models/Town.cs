using System.Collections.Generic;

namespace _011.Models
{
    public class Town
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Countrie Countrie { get; set; }

        public List<Team> Teams { get; set; } = new List<Team>();
    }
}