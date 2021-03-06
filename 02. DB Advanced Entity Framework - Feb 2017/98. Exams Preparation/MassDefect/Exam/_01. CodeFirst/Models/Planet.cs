﻿namespace _01.CodeFirst.Models
{
    using System.Collections.Generic;

    public class Planet
    {
        public Planet()
        {
            this.OriginPlanet = new HashSet<Anomalie>();
            this.TeleportPlanet = new HashSet<Anomalie>();
            this.People = new HashSet<Person>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? SunId { get; set; }

        public virtual Star Sun { get; set; }

        public int? SolarSystemId { get; set; }

        public virtual SolarSystem SolarSystem { get; set; }

        public virtual ICollection<Anomalie> OriginPlanet { get; set; }

        public virtual ICollection<Anomalie> TeleportPlanet { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}