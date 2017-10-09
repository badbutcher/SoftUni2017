namespace HandMadeHttpServer.Application.Controllers
{
    using System.Net;
    using HandMadeHttpServer.Application.Views;
    using HandMadeHttpServer.Server;
    using HandMadeHttpServer.Server.HTTP.Contracts;
    using HandMadeHttpServer.Server.HTTP.Response;

    public class UserController
    {
        public IHttpResponse RegisterGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new ReqisterView());
        }

        public IHttpResponse RegisterPost(string name)
        {
            return new RedirectResponse($"/user/{name}");
        }

        public IHttpResponse Details(string name)
        {
            Model model = new Model { ["name"] = name };
            return new ViewResponse(HttpStatusCode.OK, new UserDetalView(model));
        }
    }
}