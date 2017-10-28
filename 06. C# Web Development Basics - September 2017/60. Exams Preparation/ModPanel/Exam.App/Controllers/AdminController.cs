namespace Exam.App.Controllers
{
    using System.Linq;
    using Exam.App.Data.Model;
    using Exam.App.Infrastructure;
    using Exam.App.Models.Posts;
    using Exam.App.Services;
    using Exam.App.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;

    public class AdminController : BaseController
    {
        private readonly IUserService users;
        private readonly IAdminService admin;
        private readonly IPostService posts;
        private readonly ILogService logs;

        public AdminController()
        {
            this.users = new UserService();
            this.admin = new AdminService();
            this.posts = new PostService();
            this.logs = new LogService();
        }

        [HttpGet]
        public IActionResult Users()
        {
            if (!this.IsAdmin)
            {
                return this.Redirect("/");
            }

            var users = this.admin
                .AllUsers()
                .Select(g => $@"
                    <tr>
                        <td>{g.Id}</td>
                        <td>{g.Email}</td>
                        <td>{g.Possiton}</td>
                        <td>{g.Posts}</td>
                        <td>
                            {IsAproved(g.IsAproved, g.Id)}
                        </td>
                    </tr>");

            this.ViewModel["users"] = string.Join(string.Empty, users);

            this.Log(LogType.OpenMenu, nameof(this.Users));

            return this.View();
        }

        [HttpGet]
        public IActionResult Approve(int id)
        {
            if (!this.IsAdmin)
            {
                return this.Redirect("/");
            }

            string userEmail = this.admin.Approve(id);

            this.Log(LogType.UserApproval, userEmail);

            return this.Redirect("/admin/users");
        }

        [HttpGet]
        public IActionResult ViewPosts()
        {
            if (!this.IsAdmin)
            {
                return this.Redirect("/");
            }

            var posts = this.posts
                .AllPosts()
                .Select(a => $@"<tr>
                        <th scope=""row"">{a.Id}</th>
                        <td class=""text-capitalize"">{a.Title}</td>
                        <td>
                            <a href=""/admin/postToEdit?id={a.Id}"" class=""btn btn-sm btn-warning"">Edit</a>
                            <a href=""/admin/postToDelete?id={a.Id}"" class=""btn btn-sm btn-danger"">Delete</a>
                        </td>
                    </tr>");

            this.ViewModel["posts"] = string.Join(string.Empty, posts);

            this.Log(LogType.OpenMenu, nameof(this.ViewPosts));

            return this.View();
        }

        [HttpGet]
        public IActionResult PostToEdit(int id)
        {
            if (!this.IsAdmin)
            {
                return this.Redirect("/");
            }

            var post = this.posts.GetPostById(id);

            if (post == null)
            {
                return this.NotFound();
            }

            this.ViewModel["id"] = id.ToString();
            this.ViewModel["title"] = post.Title;
            this.ViewModel["content"] = post.Content;

            return this.View();
        }

        [HttpPost]
        public IActionResult Edit(int id, NewPostViewModel model)
        {
            if (!this.IsAdmin)
            {
                return this.Redirect("/");
            }

            this.posts.EditPost(id, model);

            this.Log(LogType.EditPost, model.Title);

            return this.Redirect("/admin/viewPosts");
        }

        [HttpGet]
        public IActionResult PostToDelete(int id)
        {
            if (!this.IsAdmin)
            {
                return this.Redirect("/");
            }

            var post = this.posts.GetPostById(id);

            if (post == null)
            {
                return this.NotFound();
            }

            this.ViewModel["id"] = id.ToString();
            this.ViewModel["title"] = post.Title;
            this.ViewModel["content"] = post.Content;

            return this.View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (!this.IsAdmin)
            {
                return this.Redirect("/");
            }

            var postTitle = this.posts.Delete(id);

            this.Log(LogType.DeletePost, postTitle);

            return this.Redirect("/admin/viewPosts");
        }

        public IActionResult Log()
        {
            this.Log(LogType.OpenMenu, nameof(this.Log));

            var rows = this.logs
                .All()
                .Select(l => $@" <div class=""card border-{l.Type.ToViewClassName()} mb-1"">
                   <div class=""card-body"">
                       <p class=""card-text"">{l}</p>
                   </div>
                </div>");

            this.ViewModel["logs"] = string.Join(string.Empty, rows);

            return this.View();
        }

        private string IsAproved(bool check, int id)
        {
            if (!check)
            {
                return $@"<a class=""btn btn-primary btn-sm"" href=""/admin/approve?id={id}"">Approve</a>";
            }

            return string.Empty;
        }
    }
}