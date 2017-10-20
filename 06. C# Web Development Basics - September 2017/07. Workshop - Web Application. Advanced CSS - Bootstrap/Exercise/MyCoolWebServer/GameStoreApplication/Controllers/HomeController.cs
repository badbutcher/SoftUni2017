namespace MyCoolWebServer.GameStoreApplication.Controllers
{
    using System.Text;
    using MyCoolWebServer.GameStoreApplication.Services;
    using Server.Http.Contracts;

    public class HomeController : BaseController
    {
        private readonly IAdminService games;

        public HomeController(IHttpRequest request)
            : base(request)
        {
            this.games = new AdminService();
        }

        public IHttpResponse Index()
        {
            StringBuilder sb = new StringBuilder();
            var allGames = this.games.GetAll();
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

                sb.Append(@"<img class=""card-image-top img-fluid img-thumbnail"" onerror=""this.src = 'https://i.ytimg.com/vi/BqJyluskTfM/maxresdefault.jpg'; "" src=""https://i.ytimg.com/vi/BqJyluskTfM/maxresdefault.jpg"">");
                sb.Append(@"<div class=""card-body"">");
                sb.Append(@"<h4 class=""card-title"">{{{title}}}</h4>");
                sb.Append(@"<p class=""card-text""><strong>Price</strong> - {{{price}}}&euro;</p>");
                sb.Append(@"<p class=""card-text""><strong>Size</strong> - {{{size}}} GB</p>");
                sb.Append(@"<p class=""card-text"">{{{description}}}</p>");
                sb.Append(@"</div>");

                sb.Append(@"<div class=""card -footer"">");
                sb.Append(@"<a class=""card-button btn btn-outline-primary"" name=""info"" href=""#"">Info</a>");
                sb.Append(@"<a class=""card-button btn btn-primary"" name=""buy"" href=""#"">Buy</a>");
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