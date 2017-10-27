namespace Exam.App.Controllers
{
    using System.Linq;
    using Exam.App.Services;
    using Exam.App.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;

    public class AdminController : BaseController
    {
        private readonly IUserService users;
        private readonly IAdminService admin;
        private readonly IPostService posts;

        public AdminController()
        {
            this.users = new UserService();
            this.admin = new AdminService();
            this.posts = new PostService();
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

            return this.View();
        }

        [HttpGet]
        public IActionResult Approve(int id)
        {
            if (!this.IsAdmin)
            {
                return this.Redirect("/");
            }

            this.admin.Approve(id);

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
                            <a href=""/admin/!!!!!!?id={a.Id}"" class=""btn btn-sm btn-warning"">Edit</a>
                            <a href=""/admin/postToDelete?id={a.Id}"" class=""btn btn-sm btn-danger"">Delete</a>
                        </td>
                    </tr>");

            this.ViewModel["posts"] = string.Join(string.Empty, posts);

            return this.View();
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

            this.posts.Delete(id);

            return this.Redirect("/admin/viewPosts");
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