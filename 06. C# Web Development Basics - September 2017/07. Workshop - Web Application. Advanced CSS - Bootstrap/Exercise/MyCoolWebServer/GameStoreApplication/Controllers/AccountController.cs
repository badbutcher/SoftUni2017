namespace MyCoolWebServer.GameStoreApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyCoolWebServer.GameStoreApplication.Infrastructure;
    using MyCoolWebServer.GameStoreApplication.Services;
    using MyCoolWebServer.GameStoreApplication.ViewModels.Account;
    using MyCoolWebServer.Server.Http;
    using MyCoolWebServer.Server.Http.Contracts;
    using MyCoolWebServer.Server.Http.Response;

    public class AccountController : Controller
    {
        private readonly IUserService users;

        public AccountController()
        {
            this.users = new UserService();
        }

        public IHttpResponse Register()
        {
            //this.SetDefaultViewData();
            return this.FileViewResponse("account/register");
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

                return this.FileViewResponse("account/register");
            }

            bool success = this.users.Create(model.Email, model.FullName, model.Password);

            if (!success)
            {
                this.LoginUser(req, model.Email);

                return new RedirectResponse("/");
            }
            else
            {
                this.AddError("This username is taken");

                return this.FileViewResponse("/account/login");
            }
        }

        public IHttpResponse Login()
        {
            //this.SetDefaultViewData();
            return this.FileViewResponse("account/login");
        }

        public IHttpResponse Login(IHttpRequest req, LoginViewModel model)
        {
            bool success = this.users.Find(model.Email, model.Password);

            if (success)
            {
                bool isAdmin = this.users.IsAdmin(model.Email);

                if (isAdmin)
                {
                    this.ViewData["anonymousDisplay"] = "none";
                    this.ViewData["authDisplay"] = "flex";
                    this.ViewData["adminDisplay"] = "flex";
                }
                else
                {
                    this.ViewData["anonymousDisplay"] = "none";
                    this.ViewData["authDisplay"] = "flex";
                    this.ViewData["adminDisplay"] = "none";
                }

                this.LoginUser(req, model.Email);

                return this.FileViewResponse("/home/index");
            }
            else
            {
                this.AddError("Password or email are wrong");

                return this.FileViewResponse("/account/login");
            }
        }

        private void LoginUser(IHttpRequest req, string email)
        {
            req.Session.Add(SessionStore.CurrentUserKey, email);
        }

        private void SetDefaultViewData() => this.ViewData["authDisplay"] = "none";
    }
}