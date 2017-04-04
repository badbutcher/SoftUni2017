namespace MassDefect.Models
{
    using System.Collections.Generic;

    public class Anomalie
    {
        public Anomalie()
        {
            this.Victims = new HashSet<Person>();
        }

        public int Id { get; set; }

        public int OriginPlanetId { get; set; }

        public virtual Planet OriginPlanet { get; set; }

        public int TeleportPlanetId { get; set; }

        public virtual Planet TeleportPlanet { get; set; }

        public virtual ICollection<Person> Victims { get; set; }
    }
}
