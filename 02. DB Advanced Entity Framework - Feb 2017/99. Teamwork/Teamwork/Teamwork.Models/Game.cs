namespace Teamwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class Game
    {
        public Game()
        {
            this.Reviews = new HashSet<Review>();
            this.Publishers = new HashSet<Publisher>();
            this.Developers = new HashSet<Developer>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsSingleplayer { get; set; }

        public bool IsMultiplayer { get; set; }

        public DateTime? RelaseDate { get; set; }

        public GameGenre GameGenre { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Publisher> Publishers { get; set; }

        public virtual ICollection<Developer> Developers { get; set; }
    }
}