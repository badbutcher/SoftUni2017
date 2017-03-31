using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Camera
    {
        public Camera()
        {
            this.PrimaryCamera = new HashSet<Photographer>();
            this.SecondaryCamera = new HashSet<Photographer>();
        }

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public bool IsFullFrame { get; set; }

        public int MinIso { get; set; }

        public int MaxIso { get; set; }

        public virtual ICollection<Photographer> PrimaryCamera { get; set; }

        public virtual ICollection<Photographer> SecondaryCamera { get; set; }
    }
}
