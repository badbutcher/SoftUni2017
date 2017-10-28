namespace Exam.App.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exam.App.Data;
    using Exam.App.Data.Model;
    using Exam.App.Models.Home;
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

        public IEnumerable<HomeUserPostsViewModel> AllPostsForUser(string search = null)
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                var query = db.Posts.AsQueryable();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(p => p.Title.ToLower().Contains(search.ToLower()));
                }

                var posts = query
                    .OrderByDescending(p => p.Id)
                    .Select(a => new HomeUserPostsViewModel
                    {
                        Content = a.Content,
                        Title = a.Title,
                        CreatedOn = a.CreatedOn,
                        CreatedBy = a.User.Email
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
                    UserId = id,
                    CreatedOn = DateTime.Now
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

        public string Delete(int id)
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                var post = db.Posts
                    .FirstOrDefault(a => a.Id == id);

                db.Posts.Remove(post);
                db.SaveChanges();

                return post.Title;
            }
        }

        public void EditPost(int id, NewPostViewModel model)
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                var post = db.Posts
                    .FirstOrDefault(a => a.Id == id);

                post.Title = model.Title;
                post.Content = model.Content;

                db.SaveChanges();
            }
        }
    }
}