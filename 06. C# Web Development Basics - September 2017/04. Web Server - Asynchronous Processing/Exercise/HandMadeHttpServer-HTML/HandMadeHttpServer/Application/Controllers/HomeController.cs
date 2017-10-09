namespace HandMadeHttpServer.Application.Controllers
{
    using System.Net;
    using HandMadeHttpServer.Application.Views;
    using HandMadeHttpServer.Server.HTTP.Contracts;
    using HandMadeHttpServer.Server.HTTP.Response;

    public class HomeController
    {
        public IHttpResponse Index()
        {
            return new ViewResponse(HttpStatusCode.OK, new HomeIndexView());
        }
    }
}