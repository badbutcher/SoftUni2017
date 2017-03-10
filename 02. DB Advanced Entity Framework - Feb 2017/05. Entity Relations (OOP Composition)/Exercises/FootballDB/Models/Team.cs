using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDB.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Logo { get; set; }//TODO: logo type

        public string Initials { get; set; }

        public int MyProperty { get; set; }
    }
}
