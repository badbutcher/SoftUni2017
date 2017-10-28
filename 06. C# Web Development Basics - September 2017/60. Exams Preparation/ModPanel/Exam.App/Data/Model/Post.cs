namespace Exam.App.Data.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}