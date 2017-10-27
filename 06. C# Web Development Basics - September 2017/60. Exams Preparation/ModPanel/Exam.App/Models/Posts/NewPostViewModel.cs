namespace Exam.App.Models.Posts
{
    using Exam.App.Infrastructure.Posts;
    using Exam.App.Infrastructure.Validation;

    public class NewPostViewModel
    {
        [Required]
        [Capitalize]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}