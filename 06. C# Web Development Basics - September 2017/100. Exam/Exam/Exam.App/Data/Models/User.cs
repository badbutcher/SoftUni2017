namespace Exam.App.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string FullName { get; set; }

        public List<Contest> Contests { get; set; } = new List<Contest>();

        public List<Submission> Submissions { get; set; } = new List<Submission>();

        public bool IsAdmin { get; set; }
    }
}