namespace Exam.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Exam.App.Data;
    using Exam.App.Data.Model;
    using Exam.App.Models.Posts;
    using Exam.App.Services.Contracts;

    public class PostService : IPostService
    {
        public IEnumerable<PostAdminViewModel> AllPosts()
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                var posts = db.Posts
                    .Select(a => new PostAdminViewModel
                    {
                        Id = a.Id,
                        Title = a.Title
                    });

                return posts.ToList();
            }
        }

        public void CreatePost(string title, string content, int id)
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                Post post = new Post()
                {
                    Title = title,
                    Content = content,
                    UserId = id
                };

                db.Posts.Add(post);
                db.SaveChanges();
            }
        }

        public Post GetPostById(int id)
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                var post = db.Posts
                    .FirstOrDefault(a => a.Id == id);

                return post;
            }
        }

        public void Delete(int id)
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                var post = db.Posts
                    .FirstOrDefault(a => a.Id == id);

                db.Posts.Remove(post);
                db.SaveChanges();
            }
        }
    }
}