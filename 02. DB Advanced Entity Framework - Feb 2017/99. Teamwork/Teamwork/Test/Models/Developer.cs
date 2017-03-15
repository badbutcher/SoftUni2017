using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Developer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime Founded { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
