namespace MyCoolWebServer.GameStoreApplication.Controllers
{
    using System;
    using System.Linq;
    using System.Text;
    using MyCoolWebServer.GameStoreApplication.Data.Models;
    using MyCoolWebServer.GameStoreApplication.Services;
    using MyCoolWebServer.Server.Http.Response;
    using Server.Http.Contracts;

    public class HomeController : BaseController
    {
        private readonly IHomeSerice games;

        public HomeController(IHttpRequest request)
            : base(request)
        {
            this.games = new HomeService();
        }

        public IHttpResponse Index()
        {
            StringBuilder sb = new StringBuilder();
            var allGames = this.games.GetAllGames();
            int gamesCount = allGames.Count;
            sb.Append(@"<div class=""text-center""><h1 class=""display-3"">SoftUni Store</h1></div>");
            sb.Append(@"<form class=""form-inline"">");
            sb.Append(@"Filter:");
            sb.Append(@"<input type=""submit"" name=""filter"" class=""btn btn-link"" value=""All""/>");
            sb.Append(@"<input type=""submit"" name=""filter"" class=""btn btn-link"" value=""Owned""/>");
            sb.Append(@"</form>");

            sb.Append(@"<div class=""card-group"">");
            for (int i = 0; i < gamesCount; i++)
            {
                if (i % 3 == 0)
                {
                    sb.Append(@"<div class=""card-group"">");
                }

                sb.Append(@"<div class=""card col-4 thumbnail"">");

                sb.Append($@"<img class=""card-image-top img-fluid img-thumbnail"" onerror=""this.src = '{allGames[i].Thumbnail}'; "" src=""{allGames[i].Thumbnail}"">");
                sb.Append(@"<div class=""card-body"">");
                sb.Append($@"<h4 class=""card-title"">{allGames[i].Title}</h4>");
                sb.Append($@"<p class=""card-text""><strong>Price</strong> - {allGames[i].Price}&euro;</p>");
                sb.Append($@"<p class=""card-text""><strong>Size</strong> - {allGames[i].Size} GB</p>");
                if (allGames[i].Description.Length > 300)
                {
                    sb.Append($@"<p class=""card-text"">{allGames[i].Description.Substring(0,300)}</p>");
                }
                else
                {
                    sb.Append($@"<p class=""card-text"">{allGames[i].Description}</p>");
                }

                sb.Append(@"</div>");

                sb.Append(@"<div class=""card -footer"">");
                sb.Append($@"<a class=""card-button btn btn-outline-primary"" name=""info"" href=""/home/game-detail/{i}"">Info</a>");
                sb.Append(@"<a class=""card-button btn btn-primary"" name=""buy"" href=""#"">Buy</a>");

                sb.Append(@"<a style=""display: {{{adminDisplay}}}"" class=""card-button btn btn-warning"" name=""edit"" href=""#"">Edit</a>");
                sb.Append(@"<a style=""display: {{{adminDisplay}}}"" class=""card-button btn btn-danger"" name=""delete"" href=""#"">Delete</a>");

                sb.Append(@"</div>");
                sb.Append(@"</div>");

                if (i + 1 % 3 == 0)
                {
                    sb.Append(@"</div>");
                }
            }

            sb.Append(@"</div>");

            this.ViewData["big-table"] = sb.ToString();

            return this.FileViewResponse(@"\home\index");
        }
    }
}