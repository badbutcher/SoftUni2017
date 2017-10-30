namespace Exam.App.Data.Models
{
    public class Contest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? UserId { get; set; }

        public User User { get; set; }

        public int? SubmissionId { get; set; }

        public Submission Submission { get; set; }
    }
}