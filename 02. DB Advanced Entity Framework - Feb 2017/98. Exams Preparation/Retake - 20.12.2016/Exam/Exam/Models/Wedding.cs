using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Wedding
    {
        public Wedding()
        {
            this.Venues = new HashSet<Venue>();
            this.Invitations = new HashSet<Invitation>();
        }

        public int Id { get; set; }

        public int? BrideId { get; set; }

        public virtual Person Bride { get; set; }

        public int? BridegroomId { get; set; }

        public virtual Person Bridegroom { get; set; }

        public DateTime Date { get; set; }

        public int? AgencyId { get; set; }

        public virtual Agency Agency { get; set; }

        public virtual ICollection<Venue> Venues { get; set; }

        public virtual ICollection<Invitation> Invitations { get; set; }
    }
}