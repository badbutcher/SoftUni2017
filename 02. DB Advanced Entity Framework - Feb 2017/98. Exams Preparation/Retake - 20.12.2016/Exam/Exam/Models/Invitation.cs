using Exam.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Invitation
    {
        public int Id { get; set; }

        public int WeddingId { get; set; }

        public virtual Wedding Wedding { get; set; }

        public int GuestId { get; set; }

        public virtual Person Guest { get; set; }

        public int? PresentId { get; set; }

        public virtual Present Present { get; set; }

        public bool Attending { get; set; }

        public FamilyType Family { get; set; }
    }
}