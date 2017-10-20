namespace MyCoolWebServer.Application.Controllers
{
    using System;
    using Application.Views.Home;
    using Server.Enums;
    using Server.Http;
    using Server.Http.Contracts;
    using Server.Http.Response;

    public class HomeController
    {
        public IHttpResponse Index()
        {
            ViewResponse response = new ViewResponse(HttpStatusCode.Ok, new IndexView());

            response.Cookies.Add(new HttpCookie("lang", "en"));

            return response;
        }

        public IHttpResponse SessionTest(IHttpRequest req)
        {
            IHttpSession session = req.Session;

            const string SessionDateKey = "saved_date";

            if (session.Get(SessionDateKey) == null)
            {
                session.Add(SessionDateKey, DateTime.UtcNow);
            }

            return new ViewResponse(
                HttpStatusCode.Ok,
                new SessionTestView(session.Get<DateTime>(SessionDateKey)));
        }
    }
}