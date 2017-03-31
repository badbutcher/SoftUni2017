using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Models
{
    public class Event
    {
        public Event()
        {
            this.ParticipatingTeams = new List<Team>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //[DisplayFormat(DataFormatString = "{0:DD/MM/YYYY HH:mm}")]
        public DateTime StartDate { get; set; }

        //[DisplayFormat(DataFormatString = "{0:DD/MM/YYYY HH:mm}")]
        public DateTime EndDate { get; set; }

        public int CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public virtual ICollection<Team> ParticipatingTeams { get; set; }
    }
}