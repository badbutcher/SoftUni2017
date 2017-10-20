namespace MyCoolWebServer.GameStoreApplication.Controllers
{
    using MyCoolWebServer.GameStoreApplication.Services;
    using MyCoolWebServer.GameStoreApplication.ViewModels.Account;
    using MyCoolWebServer.Server.Http;
    using MyCoolWebServer.Server.Http.Contracts;
    using MyCoolWebServer.Server.Http.Response;

    public class AccountController : BaseController
    {
        private readonly IUserService users;

        public AccountController(IHttpRequest request)
            : base(request)
        {
            this.users = new UserService();
        }

        public IHttpResponse Register()
        {
            return this.FileViewResponse("/account/register");
        }

        public IHttpResponse Register(IHttpRequest req, RegisterUserViewModel model)
        {
            if (model.FullName.Length < 2
                || model.FullName.Length > 30
                || model.Password.Length < 6
                || model.Password.Length > 50
                || model.Email.Length > 30
                || model.ConfirmPassword != model.Password)
            {
                this.AddError("Invalid user details");

                return this.Register();
            }

            bool success = this.users.Create(model.Email, model.FullName, model.Password);

            if (!success)
            {
                this.LoginUser(req, model.Email);

                return new RedirectResponse("/account/login");
            }
            else
            {
                this.AddError("This username is taken");

                return this.FileViewResponse("/account/login");
            }
        }

        public IHttpResponse Login()
        {
            return this.FileViewResponse("/account/login");
        }

        public IHttpResponse Login(IHttpRequest req, LoginViewModel model)
        {
            bool success = this.users.Find(model.Email, model.Password);

            if (success)
            {
                bool isAdmin = this.users.IsAdmin(model.Email);

                this.LoginUser(req, model.Email);

                return new RedirectResponse("/home/index");
            }
            else
            {
                this.AddError("Password or email are wrong");

                return this.FileViewResponse("/account/login");
            }
        }

        public IHttpResponse Logout(IHttpRequest req)
        {
            req.Session.Clear();

            return new RedirectResponse("/home/index");
        }

        private void LoginUser(IHttpRequest req, string email)
        {
            req.Session.Add(SessionStore.CurrentUserKey, email);
        }
    }
}