using System.Net;
using HandMadeHttpServer.Application.Views;
using HandMadeHttpServer.Server;
using HandMadeHttpServer.Server.HTTP.Contracts;
using HandMadeHttpServer.Server.HTTP.Response;

namespace HandMadeHttpServer.Application.Controllers
{
    public class BuyCakeController
    {
        public IHttpResponse RegisterGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new AddCakesView());
        }

        public IHttpResponse RegisterPost(string name)
        {
            return new RedirectResponse($"/user/{name}");
        }

        public IHttpResponse Details(string name)
        {
            Model model = new Model { ["name"] = name };
            return new ViewResponse(HttpStatusCode.OK, new CakeDetails(model));
        }
    }
}
