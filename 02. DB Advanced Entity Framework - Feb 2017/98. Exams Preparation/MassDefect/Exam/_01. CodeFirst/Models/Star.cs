namespace _01.CodeFirst.Models
{
    public class Star
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? SolarSystemId { get; set; }

        public virtual SolarSystem SolarSystem { get; set; }
    }
}