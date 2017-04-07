namespace Exam.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DslrCameras")]
    public class DslrCamera : Camera
    {
        public int MaxShutterSpeed { get; set; }
    }
}