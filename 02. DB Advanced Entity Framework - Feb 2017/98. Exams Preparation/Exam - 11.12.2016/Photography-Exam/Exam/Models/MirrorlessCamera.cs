namespace Exam.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MirrorlessCameras")]
    public class MirrorlessCamera : Camera
    {
        public string MaxVidoeResolution { get; set; }

        public int MaxFrameRate { get; set; }
    }
}