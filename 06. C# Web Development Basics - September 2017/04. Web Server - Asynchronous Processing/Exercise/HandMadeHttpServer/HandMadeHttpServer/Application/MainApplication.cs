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
        }
    }
}