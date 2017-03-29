namespace Teamwork.Services
{
    using System.Linq;
    using Data;
    using Models;
    public class CommentService
    {
        public void AddComment(string content)
        {
            Comment comment = new Comment
            {
                Content = content,
            };

            using (TeamworkContext context = new TeamworkContext())
            {
                context.Comments.Add(comment);
                context.SaveChanges();
            }
        }

        public void AddCommentToReview(string commnetContent, string reviewTitle)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                Comment comment = context.Comments.SingleOrDefault(c => c.Content == commnetContent);
                Review review = context.Reviews.SingleOrDefault(r => r.Name == reviewTitle);
                review.Comments.Add(comment);
                context.SaveChanges();
            }
        }
    }
}