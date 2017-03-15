using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public float Rating { get; set; }

        public Game Game { get; set; }
    }
}
