using Photo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Models
{
    public class Album
    {
        public Album()
        {
            Pictures = new List<Picture>();
            Tags = new List<Tag>();
            Photographers = new List<Photographer>();
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
