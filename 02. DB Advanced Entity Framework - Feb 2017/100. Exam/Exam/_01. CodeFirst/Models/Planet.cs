namespace _01.CodeFirst.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Planet
    {
        public Planet()
        {
            this.Telescopes = new HashSet<Telescope>();
        }

        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Range(0.0000001f, float.MaxValue)]
        public float? Mass { get; set; }

        public int StarSystemId { get; set; }

        [Required]
        public virtual StarSystem StarSystem { get; set; }

        public virtual ICollection<Telescope> Telescopes { get; set; }
    }
}