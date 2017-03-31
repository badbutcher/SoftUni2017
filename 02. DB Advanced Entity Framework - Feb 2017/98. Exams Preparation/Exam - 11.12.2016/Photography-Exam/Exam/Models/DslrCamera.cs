using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    [Table("DslrCameras")]
    public class DslrCamera : Camera
    {
        public int MaxShutterSpeed { get; set; }
    }
}