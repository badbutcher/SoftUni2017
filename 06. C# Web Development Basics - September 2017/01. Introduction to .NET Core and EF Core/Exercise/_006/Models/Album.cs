namespace _006.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Album
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string BackgroundColor { get; set; }

        public bool IsPublic { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public List<AlbumPicture> Pictures { get; set; } = new List<AlbumPicture>();
    }
}
