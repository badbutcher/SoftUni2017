namespace Exam.Models
{
    public class Lens
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public int FocalLength { get; set; }

        public float MaxAperture { get; set; }

        public string CompatibleWith { get; set; }

        public int? OwnerId { get; set; }

        public virtual Photographer Owner { get; set; }
    }
}