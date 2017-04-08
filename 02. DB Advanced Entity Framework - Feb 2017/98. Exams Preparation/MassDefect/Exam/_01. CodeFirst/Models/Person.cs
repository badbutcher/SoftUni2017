namespace _01.CodeFirst.Models
{
    using System.Collections.Generic;

    public class Person
    {
        public Person()
        {
            this.Anomalies = new HashSet<Anomalie>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? HomePlanetId { get; set; }

        public virtual Planet HomePlanet { get; set; }

        public virtual ICollection<Anomalie> Anomalies { get; set; }
    }
}