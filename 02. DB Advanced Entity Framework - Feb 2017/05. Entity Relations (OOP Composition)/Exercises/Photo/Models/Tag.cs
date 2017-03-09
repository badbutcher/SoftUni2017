using Photo.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Models
{
    public class Tag
    {
        public Tag()
        {
            Albums = new List<Album>();
        }

        public int Id { get; set; }

        [TagAttributes]
        public string Label { get; set; }

        public virtual List<Album> Albums { get; set; }
    }
}
