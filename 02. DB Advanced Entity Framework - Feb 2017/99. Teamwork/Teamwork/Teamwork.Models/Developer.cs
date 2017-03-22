namespace Teamwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Developer
    {
        public Developer()
        {
            this.Games = new HashSet<Game>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime? Founded { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}