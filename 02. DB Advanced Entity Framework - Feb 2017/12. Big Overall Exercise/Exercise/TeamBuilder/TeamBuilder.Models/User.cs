using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Models
{
    public enum Gender
    {
        Male, Female
    }

    public class User
    {
        public User()
        {
            this.CreatedEvents = new List<Event>();
            this.Teams = new List<Team>();
            this.CreatedTeams = new List<Team>();
            this.ReceivedInvitations = new List<Invitation>();
        }

        public int Id { get; set; }

        [MinLength(3)]
        public string Username { get; set; }

        [MinLength(6)]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Event> CreatedEvents { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public virtual ICollection<Team> CreatedTeams { get; set; }

        public virtual ICollection<Invitation> ReceivedInvitations { get; set; }
    }
}