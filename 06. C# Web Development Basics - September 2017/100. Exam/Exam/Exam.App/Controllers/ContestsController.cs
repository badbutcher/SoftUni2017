namespace Exam.App.Controllers
{
    using System.Linq;
    using Exam.App.Models.Contests;
    using Exam.App.Services;
    using Exam.App.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;

    public class ContestsController : BaseController
    {
        private readonly IUserService users;
        private readonly IContestService contests;

        public ContestsController()
        {
            this.users = new UserService();
            this.contests = new ContestService();
        }

        [HttpGet]
        public IActionResult ContestsHome()
        {
            var rows = this.contests
                .All()
                .Select(a => $@"
                    <tr>
                        <td scope=""row"">{a.Name}</td>
                        <td>{a.Submissions}</td>
                        <td>
                            {Actions(a.Name, a.Email)}
                        </td>
                    </tr>");

            this.ViewModel["contests"] = string.Join(string.Empty, rows);

            return this.View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (this.User.IsAuthenticated)
            {
                return this.View();
            }
            else
            {
                return this.RedirectToLogin();
            }
        }

        [HttpPost]
        public IActionResult Add(ContestViewModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }

            this.contests.Add(model.Name, this.Profile.Id);

            return this.Redirect("/contests/contestsHome");
        }

        [HttpGet]
        public IActionResult Edit(string name)
        {
            if (this.User.IsAuthenticated)
            {
                this.ViewModel["name"] = name;
                return this.View();
            }
            else
            {
                return this.RedirectToLogin();
            } 
        }

        [HttpPost]
        public IActionResult Edit(string name, ContestViewModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }

            this.contests.Edit(name, model.Name);

            return this.Redirect("/contests/contestsHome");
        }

        [HttpGet]
        public IActionResult ContestToDelete(string name)
        {
            if (this.User.IsAuthenticated)
            {
                this.ViewModel["name"] = name;
                return this.View();
            }
            else
            {
                return this.RedirectToLogin();
            }
        }

        [HttpPost]
        public IActionResult Delete(string name)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }

            this.contests.Delete(name);

            return this.Redirect("/contests/contestsHome");
        }

        [HttpGet]
        public IActionResult Back()
        {
            return this.Redirect("/contests/contestsHome");
        }

        private string Actions(string name, string email)
        {
            string html = $@"<a href = ""/contests/edit?name={name}"" class=""btn btn-sm btn-warning"">Edit</a>
                            <a href = ""/contests/contestToDelete?name={name}"" class=""btn btn-sm btn-danger"">Delete</a>";

            if (email == this.User.Name)
            {
                return html;
            }

            return string.Empty;
        }
    }
}