using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Lens
    {
        public int Id { get; set; }

        public int FocalLenght { get; set; }

        public float MaxAperture { get; set; }

        public bool CompatibleWith { get; set; }

        public int OwnerId { get; set; }

        public virtual Photographer Owner { get; set; }
    }
}