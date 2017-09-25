namespace _011.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Position
    {
        [Key]
        [MaxLength(2)]
        [MinLength(2)]
        public string Id { get; set; }

        public string Description { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();
    }
}