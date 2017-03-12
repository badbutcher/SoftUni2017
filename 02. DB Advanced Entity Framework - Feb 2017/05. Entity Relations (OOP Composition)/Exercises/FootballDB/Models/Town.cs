namespace FootballDB.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Town
    {
        //public Town()
        //{
        //    this.Teams = new HashSet<Team>();
        //}

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Country Country { get; set; }

        //public virtual ICollection<Team> Teams { get; set; }
    }
}