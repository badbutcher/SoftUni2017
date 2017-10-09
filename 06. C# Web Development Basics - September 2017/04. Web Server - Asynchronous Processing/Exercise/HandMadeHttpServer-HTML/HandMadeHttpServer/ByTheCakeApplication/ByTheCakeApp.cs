namespace HandMadeHttpServer.ByTheCakeApplication
{
    using HandMadeHttpServer.ByTheCakeApplication.Controllers;
    using HandMadeHttpServer.Server.Contracts;
    using HandMadeHttpServer.Server.Handlers;
    using HandMadeHttpServer.Server.Routing.Contracts;

    public class ByTheCakeApp : IApplication
    {
        public void Start(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig
                .AddRoute("/", new GetHandler(httpContext => new HomeController().Index()));

            appRouteConfig
                .AddRoute("/about", new GetHandler(httpContext => new HomeController().About()));

            appRouteConfig
                .AddRoute("/add", new GetHandler(httpContext => new CakesController().Add()));

            appRouteConfig
                .AddRoute(
                    "/add",
                    new PostHandler(req => new CakesController().Add(req.FormData["name"], req.FormData["price"])));

            appRouteConfig
                .AddRoute(
                    "/search",
                    new GetHandler(req => new CakesController().Search(req.UrlParameters)));
        }
    }
}