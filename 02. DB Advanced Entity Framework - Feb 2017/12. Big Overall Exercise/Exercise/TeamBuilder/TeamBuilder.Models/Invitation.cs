using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Models
{
    public class Invitation
    {
        public Invitation()
        {
            this.IsActive = true;
        }

        public int Id { get; set; }

        public int InvitedUserId { get; set; }

        public int TeamId { get; set; }

        public bool IsActive { get; set; }
    }
}