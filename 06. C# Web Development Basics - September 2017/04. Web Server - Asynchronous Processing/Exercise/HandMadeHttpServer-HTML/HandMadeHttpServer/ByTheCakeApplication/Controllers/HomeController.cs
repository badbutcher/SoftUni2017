namespace HandMadeHttpServer.ByTheCakeApplication.Controllers
{
    using HandMadeHttpServer.ByTheCakeApplication.Infrastructure;
    using HandMadeHttpServer.Server.HTTP.Contracts;

    public class HomeController : Controller
    {
        public IHttpResponse Index() => this.FileViewResponse(@"home\index");

        public IHttpResponse About() => this.FileViewResponse(@"home\about");
    }
}