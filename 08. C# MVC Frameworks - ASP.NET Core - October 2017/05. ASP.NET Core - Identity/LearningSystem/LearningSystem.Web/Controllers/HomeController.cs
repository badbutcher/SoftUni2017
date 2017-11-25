namespace LearningSystem.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using LearningSystem.Services;
    using LearningSystem.Web.Models;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly ICourseService courses;

        public HomeController(ICourseService courses)
        {
            this.courses = courses;
        }

        public async Task<IActionResult> Index()
        {
            var result = await this.courses.Active();

            return View(result);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}