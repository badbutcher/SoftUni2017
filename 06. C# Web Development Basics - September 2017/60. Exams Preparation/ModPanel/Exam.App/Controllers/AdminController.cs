namespace Exam.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Exam.App.Services;
    using Exam.App.Services.Contracts;
    using SimpleMvc.Framework.Contracts;

    public class AdminController : BaseController
    {
        private readonly IUserService users;

        public AdminController()
        {
            this.users = new UserService();
        }

        public IActionResult All()
        {
            if (!this.IsAdmin)
            {
                return this.Redirect("/");
            }

            var allGames = this.users
                .AllUsers()
                .Select(g => $@"
                    <tr>
                        <td>{g.Id}</td>
                        <td>{g.Name}</td>
                        <td>{g.Size} GB</td>
                        <td>{g.Price} &euro;</td>
                        <td>
                            <a class=""btn btn-warning btn-sm"" href=""/admin/edit?id={g.Id}"">Edit</a>
                            <a class=""btn btn-danger btn-sm"" href=""/admin/delete?id={g.Id}"">Delete</a>
                        </td>
                    </tr>");

            this.ViewModel["games"] = string.Join(string.Empty, allGames);

            return this.View();
        }
    }
}
