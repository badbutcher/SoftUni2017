namespace Teamwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Publisher
    {
        public Publisher()
        {
            this.Games = new HashSet<Game>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string FoundedInCountryName { get; set; }

        public string FoundedInCityName { get; set; }

        public DateTime? FoundedIn { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}