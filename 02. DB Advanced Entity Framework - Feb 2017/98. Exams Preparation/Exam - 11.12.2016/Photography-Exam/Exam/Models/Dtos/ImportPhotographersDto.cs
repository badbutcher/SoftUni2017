namespace Exam.Models.Dtos
{
    public class ImportPhotographersDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public int[] Lenses { get; set; }
    }
}