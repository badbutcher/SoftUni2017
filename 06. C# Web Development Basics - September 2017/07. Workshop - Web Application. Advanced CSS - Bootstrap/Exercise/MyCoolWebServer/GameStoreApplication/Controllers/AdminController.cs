using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCoolWebServer.GameStoreApplication.Data.Models;
using MyCoolWebServer.GameStoreApplication.Infrastructure;
using MyCoolWebServer.GameStoreApplication.Services;
using MyCoolWebServer.GameStoreApplication.ViewModels.Admin;
using MyCoolWebServer.Server.Http.Contracts;
using MyCoolWebServer.Server.Http.Response;

namespace MyCoolWebServer.GameStoreApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService games;

        public AdminController()
        {
            this.games = new AdminService();
        }

        public IHttpResponse AddGame()
        {
            this.ViewData["anonymousDisplay"] = "none";
            this.ViewData["authDisplay"] = "flex";
            this.ViewData["adminDisplay"] = "flex";

            return this.FileViewResponse("/admin/add-game");
        }

        public IHttpResponse AddGame(IHttpRequest req, AddGameViewModel model)
        {
            this.ViewData["anonymousDisplay"] = "none";
            this.ViewData["authDisplay"] = "flex";
            this.ViewData["adminDisplay"] = "flex";

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

        public IHttpResponse ListGames()
        {
            this.ViewData["anonymousDisplay"] = "none";
            this.ViewData["authDisplay"] = "flex";
            this.ViewData["adminDisplay"] = "flex";

            var allGames = this.games
                .GetAll()
                .Select(a => $@"<tr>
                                    <td>{a.Id}</td>
                                    <td>{a.Name}</td>
                                    <td>{a.Size:F2} GB</td>
                                    <td>{a.Price:F2} &euro;</td>
                                    <td>
                                        <a class=""btn btn-warning"" href=""/admin/edit-game/{a.Id}"">Edit</a>
                                        <a class=""btn btn-danger"" href=""/admin/delete-game/{a.Id}"">Delete</a>
                                    </td>
                                </tr>");

            var result = string.Join(Environment.NewLine, allGames);

            this.ViewData["games"] = result;

            return this.FileViewResponse("/admin/list-games");
        }

        public IHttpResponse DeleteGame(int id)
        {
            this.ViewData["anonymousDisplay"] = "none";
            this.ViewData["authDisplay"] = "flex";
            this.ViewData["adminDisplay"] = "flex";

            games.DeleteGameById(id);

            return new RedirectResponse($"/admin/list-games");
        }

        public IHttpResponse GetGameById(int id, string type)
        {
            this.ViewData["anonymousDisplay"] = "none";
            this.ViewData["authDisplay"] = "flex";
            this.ViewData["adminDisplay"] = "flex";

            var result = games.GetGameById(id);

            this.ViewData["title"] = result.Title;
            this.ViewData["description"] = result.Description;
            this.ViewData["image"] = result.Image;
            this.ViewData["price"] = result.Price.ToString();
            this.ViewData["size"] = result.Size.ToString();
            this.ViewData["url"] = result.VideoId;
            this.ViewData["date"] = result.ReleaseDate.ToString();

            return this.FileViewResponse($"/admin/{type}-game");
        }

        public IHttpResponse EditGame(int id, Game g)
        {
            var game = games.GetGameById(id);
            games.EditGameById(id, g.Title, g.Description, g.Image, g.Price, g.Size, g.VideoId, g.ReleaseDate);

            return new RedirectResponse($"/admin/list-games");
        }
    }
}
