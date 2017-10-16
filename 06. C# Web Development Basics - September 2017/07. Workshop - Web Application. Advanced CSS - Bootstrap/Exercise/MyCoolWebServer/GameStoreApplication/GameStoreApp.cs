namespace MyCoolWebServer.GameStoreApplication
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using MyCoolWebServer.GameStoreApplication.Controllers;
    using MyCoolWebServer.GameStoreApplication.Data;
    using MyCoolWebServer.GameStoreApplication.ViewModels.Account;
    using MyCoolWebServer.Server.Contracts;
    using MyCoolWebServer.Server.Routing.Contracts;

    public class GameStoreApp : IApplication
    {
        public void InitializeDatabase()
        {
            using (GameStoreDbContext db = new GameStoreDbContext())
            {
                db.Database.Migrate();
            }
        }

        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.Get("/", req => new HomeController().Index());

            appRouteConfig.Get("account/register", req => new AccountController().Register());

            appRouteConfig.Post("account/register",
                    req => new AccountController().Register(
                        req,
                        new RegisterUserViewModel
                        {
                            Email = req.FormData["email"],
                            FullName = req.FormData["full-name"],
                            Password = req.FormData["password"],
                            ConfirmPassword = req.FormData["confirm-password"]
                        }));

            appRouteConfig.Get("account/login", req => new AccountController().Login());

            appRouteConfig.Post("account/login",
                    req => new AccountController().Login(
                        req,
                        new LoginViewModel
                        {
                            Password = req.FormData["password"],
                            Email = req.FormData["email"]
                        }));
        }
    }
}