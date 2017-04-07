using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Present
    {
        [NotMapped]
        public Person Owner { get; set; }

        public int? InvitationId { get; set; }

        public virtual Invitation Invitation { get; set; }
    }
}
