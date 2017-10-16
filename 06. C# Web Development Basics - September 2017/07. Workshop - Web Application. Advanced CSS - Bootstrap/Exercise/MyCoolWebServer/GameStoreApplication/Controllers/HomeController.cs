using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoolWebServer.GameStoreApplication.Controllers
{
    using Infrastructure;
    using Server.Http.Contracts;

    public class HomeController : Controller
    {
        public IHttpResponse Index() => this.FileViewResponse(@"home\index");
    }
}