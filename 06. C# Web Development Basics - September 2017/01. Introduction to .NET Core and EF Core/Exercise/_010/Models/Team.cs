namespace _010.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Logo { get; set; }

        [MaxLength(3)]
        [MinLength(3)]
        public string Initials { get; set; }

        public Color PrimaryColor { get; set; }

        public Color SecondaryColor { get; set; }

        public Town Town { get; set; }

        public decimal Budget { get; set; }
    }
}