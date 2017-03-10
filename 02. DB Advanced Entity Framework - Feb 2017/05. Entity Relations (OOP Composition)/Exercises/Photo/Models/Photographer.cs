namespace Photo.Models
{
    using System;
    using System.Collections.Generic;

    public class Photographer
    {
        public Photographer()
        {
           this.Albums = new List<Album>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime BirthDate { get; set; }

        public virtual List<Album> Albums { get; set; }
    }
}