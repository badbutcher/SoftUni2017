namespace LearningSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using LearningSystem.Data.Models;
    using LearningSystem.Services.Contracts;
    using LearningSystem.Services.Models.Course;
    using LearningSystem.Web.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CoursesController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ICourseService courses;

        public CoursesController(ICourseService courses, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.courses = courses;
        }

        [Authorize(Roles = GlocalConstants.Administrator)]
        public IActionResult Add()
        {
            return this.View(new AddCourseModel
            {
                Trainers = this.GetAllTrainers()
            });
        }

        [HttpPost]
        [Authorize(Roles = GlocalConstants.Administrator)]
        public IActionResult Add(AddCourseModel courseModel)
        {
            if (!ModelState.IsValid)
            {
                courseModel.Trainers = this.GetAllTrainers();
                return this.View(courseModel);
            }

            this.courses.Add(
                courseModel.Name,
                courseModel.Description,
                courseModel.TrainerId,
                courseModel.StartDate,
                courseModel.EndDate);

            return this.RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private IEnumerable<SelectListItem> GetAllTrainers()
        {
            var trainers = this.userManager.GetUsersInRoleAsync(GlocalConstants.Trainer).Result;

            return trainers.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            });
        }
    }
}