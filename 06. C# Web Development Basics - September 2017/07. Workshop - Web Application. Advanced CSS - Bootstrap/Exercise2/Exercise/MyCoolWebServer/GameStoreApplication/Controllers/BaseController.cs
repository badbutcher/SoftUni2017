namespace MyCoolWebServer.GameStoreApplication.Controllers
{
    using Infrastructure;

    public abstract class BaseController : Controller
    {
        protected override string ApplicationDirectory => "GameStoreApplication";
    }
}