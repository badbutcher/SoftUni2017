namespace MyCoolWebServer.GameStoreApplication
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using MyCoolWebServer.GameStoreApplication.Controllers;
    using MyCoolWebServer.GameStoreApplication.Data;
    using MyCoolWebServer.GameStoreApplication.Data.Models;
    using MyCoolWebServer.GameStoreApplication.ViewModels.Account;
    using MyCoolWebServer.GameStoreApplication.ViewModels.Admin;
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
            appRouteConfig.Get("/home/index", req => new HomeController(req).Index());

            appRouteConfig.Get("/account/register", req => new AccountController(req).Register());

            appRouteConfig.Post("/account/register",
                    req => new AccountController(req).Register(
                        req,
                        new RegisterUserViewModel
                        {
                            Email = req.FormData["email"],
                            FullName = req.FormData["full-name"],
                            Password = req.FormData["password"],
                            ConfirmPassword = req.FormData["confirm-password"]
                        }));

            appRouteConfig.Get("/account/login", req => new AccountController(req).Login());

            appRouteConfig.Post("/account/login",
                    req => new AccountController(req).Login(
                        req,
                        new LoginViewModel
                        {
                            Password = req.FormData["password"],
                            Email = req.FormData["email"]
                        }));

            appRouteConfig.Get("/admin/add-game", req => new AdminController(req).AddGame());

            appRouteConfig.Post("/admin/add-game",
                   req => new AdminController(req).AddGame(
                       req,
                       new AddGameViewModel
                       {
                           Title = req.FormData["title"],
                           Description = req.FormData["description"],
                           Image = req.FormData["image-url"],
                           Price = decimal.Parse(req.FormData["price"]),
                           Size = double.Parse(req.FormData["size"]),
                           VideoId = req.FormData["video-url"],
                           ReleaseDate = DateTime.Parse(req.FormData["release-date"]),
                       }));

            appRouteConfig.Get("/admin/list-games",
                   req => new AdminController(req).ListGames());

            appRouteConfig.Get("/admin/delete-game/{(?<id>[0-9]+)}",
                  req => new AdminController(req).GetGameById(int.Parse(req.UrlParameters["id"]), "delete"));

            appRouteConfig.Post("/admin/delete-game/{(?<id>[0-9]+)}",
                  req => new AdminController(req).DeleteGame(int.Parse(req.UrlParameters["id"])));

            appRouteConfig.Get("/admin/edit-game/{(?<id>[0-9]+)}",
                  req => new AdminController(req).GetGameById(int.Parse(req.UrlParameters["id"]), "edit"));

            appRouteConfig.Post("/admin/edit-game/{(?<id>[0-9]+)}",
                 req => new AdminController(req).EditGame(int.Parse(req.UrlParameters["id"]), new Game
                 {
                     Title = req.FormData["title"],
                     Description = req.FormData["description"],
                     Image = req.FormData["image-url"],
                     Price = decimal.Parse(req.FormData["price"]),
                     Size = double.Parse(req.FormData["size"]),
                     VideoId = req.FormData["video-url"],
                     ReleaseDate = DateTime.Parse(req.FormData["release-date"]),
                 }));

            appRouteConfig
                .Get(
                    "/account/logout",
                    req => new AccountController(req).Logout(req));
        }
    }
}