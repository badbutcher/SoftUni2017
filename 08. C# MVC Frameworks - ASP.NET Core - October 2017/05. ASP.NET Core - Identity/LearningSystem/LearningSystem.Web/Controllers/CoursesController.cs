namespace LearningSystem.Web.Controllers
{
    using System.Threading.Tasks;
    using LearningSystem.Data;
    using LearningSystem.Data.Models;
    using LearningSystem.Services;
    using LearningSystem.Services.Models;
    using LearningSystem.Web.Infrastructure.Extensions;
    using LearningSystem.Web.Models.Courses;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CoursesController : Controller
    {
        private readonly ICourseService courses;
        private readonly UserManager<User> userManager;

        public CoursesController(ICourseService courses, UserManager<User> userManager)
        {
            this.courses = courses;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = new CourseDetailsViewModel
            {
                Course = await this.courses.ByIdAsync<CourseDetailsServiceModel>(id)
            };

            if (model.Course == null)
            {
                return this.NotFound();
            }

            if (User.Identity.IsAuthenticated)
            {
                var userId = this.userManager.GetUserId(User);

                model.UserIsEnrolledCourse = await this.courses.StudentIsEnrolledCourseAsync(id, userId);
            }

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SubmitExam(int id, IFormFile exam)
        {
            if (!exam.FileName.EndsWith(".zip") || exam.Length > DataConstants.CourseExamSubmissionFileLenght)
            {
                TempData.AddErrorMessage("Your submission should be a .zip file with max of 2mb size.");
                return this.RedirectToAction(nameof(this.Details), new { id });
            }

            var fileContents = await exam.ToByteArrayAsync();
            var userId = this.userManager.GetUserId(User);

            var success = await this.courses.SaveExamSubmission(id, userId, fileContents);

            if (!success)
            {
                return this.BadRequest();
            }

            TempData.AddSuccessMessage("Exam saved successfully!");
            return this.RedirectToAction(nameof(this.Details), new { id });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SignUp(int id)
        {
            var userId = this.userManager.GetUserId(User);

            var success = await this.courses.SignUpStudentAsync(id, userId);

            if (!success)
            {
                return this.BadRequest();
            }

            TempData.AddSuccessMessage("Thank you for the registration.");

            return this.RedirectToAction(nameof(this.Details), new { id });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SignOut(int id)
        {
            var userId = this.userManager.GetUserId(User);

            var success = await this.courses.SignOutStudentAsync(id, userId);

            if (!success)
            {
                return this.BadRequest();
            }

            TempData.AddSuccessMessage("Sorry to see you go.");

            return this.RedirectToAction(nameof(this.Details), new { id });
        }
    }
}