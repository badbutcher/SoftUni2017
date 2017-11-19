namespace LearningSystem.Web.Controllers
{
    using System.Diagnostics;
    using LearningSystem.Services.Contracts;
    using LearningSystem.Web.Models;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly ICourseService courses;

        public HomeController(ICourseService courses)
        {
            this.courses = courses;
        }

        public IActionResult Index()
        {
            var allCourses = this.courses.All();

            return this.View(allCourses);
        }

        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}