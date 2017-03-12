namespace FootballDB.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Continent
    {
        public Continent()
        {
            this.Continents = new HashSet<Continent>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Continent> Continents { get; set; }
    }
}