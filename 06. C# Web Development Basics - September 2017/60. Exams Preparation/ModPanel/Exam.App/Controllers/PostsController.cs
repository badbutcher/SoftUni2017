namespace Exam.App.Controllers
{
    using Exam.App.Data.Model;
    using Exam.App.Models.Posts;
    using Exam.App.Services;
    using Exam.App.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;

    public class PostsController : BaseController
    {
        private readonly IPostService posts;

        public PostsController()
        {
            this.posts = new PostService();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(NewPostViewModel post)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/users/login");
            }

            this.posts.CreatePost(Capitalize(post.Title), post.Content, this.Profile.Id);

            if (this.IsAdmin)
            {
                this.Log(LogType.CreatePost, post.Title);
            }

            return this.Redirect("/home/index");
        }

        private string Capitalize(string str)
        {
            if (str == null)
            {
                return null;
            }

            if (str.Length > 1)
            {
                return char.ToUpper(str[0]) + str.Substring(1);
            }

            return str.ToUpper();
        }
    }
}