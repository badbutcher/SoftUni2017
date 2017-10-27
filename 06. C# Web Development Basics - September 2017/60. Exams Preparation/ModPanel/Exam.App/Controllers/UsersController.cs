namespace Exam.App.Controllers
{
    using Exam.App.Data.Model;
    using Exam.App.Models.Users;
    using Exam.App.Services;
    using Exam.App.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;

    public class UsersController : BaseController
    {
        private const string RegisterError = "<p>Check your form for errors.</p><p> E-mails must have at least one '@' and one '.' symbols.</p><p>Passwords must be at least 6 symbols and must contain at least 1 uppercase, 1 lowercase letter and 1 digit.</p><p>Confirm password must match the provided password.</p>";
        private const string EmailExistsError = "E-mail is already taken.";
        private const string LoginError = "<p>Invalid credentials.</p>";

        private IUserService users;

        public UsersController()
        {
            this.users = new UserService();
        }

        public IActionResult Register() => this.View();

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (model.Password != model.ConfirmPassword
                || !this.IsValidModel(model))
            {
                this.ShowError(RegisterError);
                return this.View();
            }

            var result = this.users.Create(model.Email, model.Password, (Position)model.Position);

            if (result)
            {
                return this.Redirect("/users/login");
            }
            else
            {
                this.ShowError(EmailExistsError);
                return this.View();
            }
        }

        public IActionResult Login() => this.View();

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.ShowError(LoginError);
                return this.View();
            }

            if (!this.users.IsAproved(model.Email))
            {
                this.ShowError("Wait for approval");
                return this.View();
            }

            if (this.users.UserExists(model.Email, model.Password))
            {
                this.SignIn(model.Email);
                return this.Redirect("/");
            }
            else
            {
                this.ShowError(LoginError);
                return this.View();
            }
        }

        public IActionResult Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}