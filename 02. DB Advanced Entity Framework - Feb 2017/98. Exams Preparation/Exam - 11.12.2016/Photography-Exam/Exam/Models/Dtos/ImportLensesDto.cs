namespace Exam.Models.Dtos
{
    public class ImportLensesDto
    {
        public string Make { get; set; }

        public int FocalLength { get; set; }

        public float MaxAperture { get; set; }

        public string CompatibleWith { get; set; }
    }
}