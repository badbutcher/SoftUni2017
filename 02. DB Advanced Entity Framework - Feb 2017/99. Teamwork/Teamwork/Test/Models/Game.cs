using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models.Enums;

namespace Test.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Publisher Publisher { get; set; }

        public Developer Developer { get; set; }

        public Genders Gender { get; set; }

        public Ost Ost { get; set; }

        public DateTime RelaseDate { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
