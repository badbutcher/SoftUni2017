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
<<<<<<< HEAD

            appRouteConfig.AddRoute(
                "/register",
                new PostHandler(
                    httpContext => new UserController()
                    .RegisterPost(httpContext.FromData["name"])));

            appRouteConfig.AddRoute(
                "/register",
                new GetHandler(httpContext => new UserController().RegisterGet()));

            appRouteConfig.AddRoute(
                "/user/{(?<name>[a-z]+)}",
                new GetHandler(httpContext => new UserController()
                .Details(httpContext.UrlParameters["name"])));

            //appRouteConfig.AddRoute(
            //    "/add",
            //    new GetHandler(httpContext => new BuyCakeController().Index()));

            //appRouteConfig.AddRoute(
            //    "/add/{(?<name>[a-z]+)}",
            //    new GetHandler(httpContext => new BuyCakeController()
            //    .Details(httpContext.UrlParameters["name"])));

            appRouteConfig.AddRoute(
                "/serach",
                new GetHandler(httpContext => new HomeController().Index()));

            appRouteConfig.AddRoute(
                "/about",
                new GetHandler(httpContext => new HomeController().Index()));

            appRouteConfig.AddRoute(
                "/cakes",
                new GetHandler(httpContext => new HomeController().Index()));

            appRouteConfig.AddRoute(
                "/stores",
                new GetHandler(httpContext => new HomeController().Index()));
=======
>>>>>>> parent of c0412fc... Commit
        }
    }
}