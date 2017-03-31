using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [MinLength(3), MaxLength(3)]
        public string Acronym { get; set; }
    }
}