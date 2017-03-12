namespace FootballDB.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Competition
    {
        public Competition()
        {
            this.Games = new HashSet<Game>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public CompetitionType Type { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}