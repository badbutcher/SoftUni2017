namespace Photo.Models
{
    using System.Collections.Generic;
    using Photo.Attributes;

    public class Tag
    {
        public Tag()
        {
            this.Albums = new List<Album>();
        }

        public int Id { get; set; }

        [TagAttributes]
        public string Label { get; set; }

        public virtual List<Album> Albums { get; set; }
    }
}