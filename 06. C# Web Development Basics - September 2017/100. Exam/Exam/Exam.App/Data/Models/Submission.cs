namespace Exam.App.Data.Models
{
    using System.Collections.Generic;

    public class Submission
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public int? UserId { get; set; }

        public User User { get; set; }

        public List<Contest> Contests { get; set; } = new List<Contest>();
    }
}