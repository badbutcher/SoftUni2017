namespace Photo.Models
{
    using System.Collections.Generic;

    public class Picture
    {
        public Picture()
        {
            this.Albums = new List<Album>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Caption { get; set; }

        public string PathOfFile { get; set; }

        public virtual List<Album> Albums { get; set; }
    }
}