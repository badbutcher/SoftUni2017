namespace Exam.App.Data.Model
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

        public bool IsAdmin { get; set; }

        public bool IsApproved { get; set; }

        public Position Position { get; set; }

        public List<Post> Posts { get; set; } = new List<Post>();
    }
}