namespace Cars.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CustomersController : Controller
    {
        public IActionResult Ascending()
        {
            return View();
        }

        public IActionResult Descending()
        {
            return View();
        }
    }
}