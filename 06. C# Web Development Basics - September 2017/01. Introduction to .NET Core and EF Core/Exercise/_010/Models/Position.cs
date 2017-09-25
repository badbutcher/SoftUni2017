namespace _010.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Position
    {
        [Key]
        [MaxLength(2)]
        [MinLength(2)]
        public string Id { get; set; }

        public string Description { get; set; }
    }
}