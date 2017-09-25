namespace _010.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Countrie
    {
        [Key]
        [MaxLength(3)]
        [MinLength(3)]
        public string Id { get; set; }

        public string Name { get; set; }

        public Continent Continent { get; set; }
    }
}