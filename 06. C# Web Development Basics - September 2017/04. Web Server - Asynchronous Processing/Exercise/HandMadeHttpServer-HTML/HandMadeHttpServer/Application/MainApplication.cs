namespace HandMadeHttpServer.Application
{
    using HandMadeHttpServer.Application.Controllers;
    using HandMadeHttpServer.Server.Contracts;
    using HandMadeHttpServer.Server.Handlers;
    using HandMadeHttpServer.Server.Routing.Contracts;

    public class MainApplication : IApplication
    {
        public void Start(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.AddRoute("/", new GetHandler(httpContext => new HomeController().Index()));

            appRouteConfig.AddRoute(
                "/register",
                new PostHandler(
                    httpContext => new UserController()
                    .RegisterPost(httpContext.FormData["name"])));

            appRouteConfig.AddRoute(
                "/register",
                new GetHandler(httpContext => new UserController().RegisterGet()));

            appRouteConfig.AddRoute(
                "/user/{(?<name>[a-z]+)}",
                new GetHandler(httpContext => new UserController()
                .Details(httpContext.UrlParameters["name"])));
        }
    }
}