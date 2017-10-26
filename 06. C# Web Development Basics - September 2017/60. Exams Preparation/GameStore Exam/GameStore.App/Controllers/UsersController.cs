namespace GameStore.App.Controllers
{
    using GameStore.App.Models.Users;
    using GameStore.App.Services;
    using GameStore.App.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;

    public class UsersController : BaseController
    {
        private IUserService users;

        public UsersController()
        {
            this.users = new UserService();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (model.Password != model.ConfirmPassword || !this.IsValidModel(model))
            {
                this.ShowError("Email or password are wrong");
                return this.View();
            }

            bool result = users.Create(model.Email, model.Name, model.Password);

            if (result)
            {
                return this.RedirectToAction("/users/login");
            }
            else
            {
                this.ShowError("Email is taken");
                return this.View();
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.ShowError("Email or password are wrong");
                return this.View();
            }

            if (this.users.Exists(model.Email, model.Password))
            {
                this.SignIn(model.Email);
                return this.RedirectToAction("/home/index");
            }
            else
            {
                this.ShowError("Email or password are wrong");
                return this.View();
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.SignOut();
            return this.RedirectToAction("/home/index");
        }
    }
}