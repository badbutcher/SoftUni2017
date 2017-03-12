namespace FootballDB.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Logo { get; set; }

        [MinLength(3)]
        [MaxLength(3)]
        public string Initials { get; set; }

        public int PirmaryColorId { get; set; }

        [Required]
        public Color PirmaryColor { get; set; }

        public int SecondaryColorId { get; set; }

        [Required]
        public Color SecondaryColor { get; set; }

        public Town Town { get; set; }

        public decimal Budget { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}