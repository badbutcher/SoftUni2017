using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamwork.Models.Enums;

namespace Teamwork.Models.Anonymous
{
    public class GetGamesByGenreAnonymous
    {
        public string Name { get; set; }

        public bool SP { get; set; }

        public bool MP { get; set; }

        public GameGenre Genre { get; set; }
    }
}
