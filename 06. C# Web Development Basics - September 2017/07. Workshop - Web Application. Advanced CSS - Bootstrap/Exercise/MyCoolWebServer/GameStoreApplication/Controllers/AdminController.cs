using System;
using System.Collections.Generic;
using System.Text;
using MyCoolWebServer.GameStoreApplication.Infrastructure;
using MyCoolWebServer.GameStoreApplication.Services;
using MyCoolWebServer.GameStoreApplication.ViewModels.Admin;
using MyCoolWebServer.Server.Http.Contracts;

namespace MyCoolWebServer.GameStoreApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService games;

        public AdminController()
        {
            this.games = new AdminService();
        }
        public IHttpResponse AddGame(IHttpRequest req, AddGameViewModel model)
        {
            this.games.Add(
                model.Title,
                model.Description,
                model.Image,
                model.Price,
                model.Size,
                model.VideoId,
                model.ReleaseDate.Value);

            return this.FileViewResponse("/admin/add-game");
        }

        public IHttpResponse AddGame()
        {
            this.ViewData["anonymousDisplay"] = "none";
            this.ViewData["authDisplay"] = "flex";
            this.ViewData["adminDisplay"] = "flex";

            return this.FileViewResponse("/admin/add-game");
        }
    }
}
