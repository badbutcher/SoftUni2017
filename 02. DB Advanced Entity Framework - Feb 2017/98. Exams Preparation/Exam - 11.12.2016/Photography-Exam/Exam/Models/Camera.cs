﻿using System;
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
            this.PrimaryCamerasPhotographers = new HashSet<Photographer>();
            this.SecondaryCamerasPhotographers = new HashSet<Photographer>();
        }

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public bool IsFullFrame { get; set; }

        public int MinIso { get; set; }

        public int MaxIso { get; set; }

        public virtual ICollection<Photographer> PrimaryCamerasPhotographers { get; set; }

        public virtual ICollection<Photographer> SecondaryCamerasPhotographers { get; set; }
    }
}
