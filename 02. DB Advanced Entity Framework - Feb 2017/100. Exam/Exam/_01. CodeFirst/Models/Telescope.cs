namespace _01.CodeFirst.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Telescope
    {
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        public string Location { get; set; }

        [Range(0.0000001f, float.MaxValue)]
        public float? MirrorDiameter { get; set; }

        public int? OrbitingPlanetId { get; set; }

        public virtual Planet OrbitingPlanet { get; set; }
    }
}