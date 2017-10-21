namespace SimpleMvc.App.Controllers
{
    using SimpleMvc.App.Models;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using SimpleMvc.Framework.Controllers;

    public class HomeController : Controller
    {
        public IActionResult Index(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IndexModel model)
        {
            return View();
        }
    }
}