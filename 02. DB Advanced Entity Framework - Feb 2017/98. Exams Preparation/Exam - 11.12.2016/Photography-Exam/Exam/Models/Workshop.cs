using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Workshop
    {
        public Workshop()
        {
            this.Participants = new HashSet<Photographer>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        public float PricePerParticipant  { get; set; }

        public int TrainerId { get; set; }

        public virtual Photographer Trainer { get; set; }

        public virtual ICollection<Photographer> Participants { get; set; }
    }
}