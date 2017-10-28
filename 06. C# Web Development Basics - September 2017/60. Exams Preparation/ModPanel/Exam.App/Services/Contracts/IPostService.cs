namespace Exam.App.Services.Contracts
{
    using System.Collections.Generic;
    using Exam.App.Data.Model;
    using Exam.App.Models.Home;
    using Exam.App.Models.Posts;

    public interface IPostService
    {
        void CreatePost(string title, string content, int id);

        IEnumerable<PostAdminViewModel> AllPosts();

        string Delete(int id);

        Post GetPostById(int id);

        void EditPost(int id, NewPostViewModel model);

        IEnumerable<HomeUserPostsViewModel> AllPostsForUser(string search = null);
    }
}