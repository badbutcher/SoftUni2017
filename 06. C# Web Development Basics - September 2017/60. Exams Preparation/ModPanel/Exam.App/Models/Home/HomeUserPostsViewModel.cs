namespace Exam.App.Models.Home
{
    using System;

    public class HomeUserPostsViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}