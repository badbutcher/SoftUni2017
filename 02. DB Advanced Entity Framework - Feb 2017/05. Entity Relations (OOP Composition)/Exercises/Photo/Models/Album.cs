namespace Photo.Models
{
    using System.Collections.Generic;

    public class Album
    {
        public Album()
        {
            this.Pictures = new List<Picture>();
            this.Tags = new List<Tag>();
            this.Photographers = new List<Photographer>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string BackgroundColor { get; set; }

        public bool IsPublic { get; set; }

        public virtual List<Picture> Pictures { get; set; }

        public virtual List<Tag> Tags { get; set; }

        public virtual List<Photographer> Photographers { get; set; }

        public int OwnerId { get; set; }
    }
}