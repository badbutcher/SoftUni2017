namespace Exam.App.Controllers
{
    using Exam.App.Services;
    using Exam.App.Services.Contracts;
    using SimpleMvc.Framework.Contracts;

    public class HomeController : BaseController
    {
        private IUserService users;

        public HomeController()
        {
            this.users = new UserService();
        }

        public IActionResult Index()
        {
            if (this.User.IsAuthenticated)
            {
                string user = this.users.GetUserName(this.User.Name);
                this.ViewModel["name"] = user;
            }

            return this.View();
        }
    }
}