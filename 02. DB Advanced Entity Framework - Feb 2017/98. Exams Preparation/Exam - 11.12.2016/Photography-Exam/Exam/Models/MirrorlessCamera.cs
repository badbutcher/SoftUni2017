using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    [Table("MirrorlessCameras")]
    public class MirrorlessCamera : Camera
    {
        public string MaxVidoeResolution { get; set; }

        public int MaxFrameRate { get; set; }

    }
}