namespace _01.CodeFirst.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Star
    {
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, Range(2400, int.MaxValue)]
        public int? Temperature { get; set; }

        public int StarSystemId { get; set; }

        [Required]
        public virtual StarSystem StarSystem { get; set; }
    }
}