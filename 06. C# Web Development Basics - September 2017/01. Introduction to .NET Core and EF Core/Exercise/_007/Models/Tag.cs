using System;
using System.Collections.Generic;
using System.Text;
using _007.Validations;

namespace _007.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Tag]
        public string Name { get; set; }

        public List<AlbumTag> Albums { get; set; } = new List<AlbumTag>();
    }
}