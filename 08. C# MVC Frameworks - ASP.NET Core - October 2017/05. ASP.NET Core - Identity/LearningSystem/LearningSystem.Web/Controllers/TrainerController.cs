namespace LearningSystem.Web.Controllers
{
    using System.Threading.Tasks;
    using LearningSystem.Data.Models;
    using LearningSystem.Services;
    using LearningSystem.Services.Models;
    using LearningSystem.Web.Models.Trainers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = WebConstats.TrainerRole)]
    public class TrainerController : Controller
    {
        private readonly ITrainerService trainers;
        private readonly ICourseService courses;
        private readonly UserManager<User> userManager;

        public TrainerController(ITrainerService trainers, ICourseService courses, UserManager<User> userManager)
        {
            this.trainers = trainers;
            this.courses = courses;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Courses()
        {
            var userId = this.userManager.GetUserId(User);
            var courses = await this.trainers.CoursesAsync(userId);

            return this.View(courses);
        }

        public async Task<IActionResult> Students(int id)
        {
            var userId = this.userManager.GetUserId(User);

            if (!await this.trainers.IsTrainer(id, userId))
            {
                return this.BadRequest();
            }

            var students = await this.trainers.StudentInCourseAsync(id);

            return this.View(new StudentsInCourseViewModel
            {
                Students = students,
                Course = await this.courses.ByIdAsync<CourseListingServiceModel>(id)
            });
        }

        [HttpPost]
        public async Task<IActionResult> GradeStudnet(int id, string studentId, Grade grade)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                return this.BadRequest();
            }

            var userId = this.userManager.GetUserId(User);

            if (!await this.trainers.IsTrainer(id, userId))
            {
                return this.BadRequest();
            }

            var success = await this.trainers.AddGradeAsync(id, studentId, grade);

            if (!success)
            {
                return this.BadRequest();
            }

            return this.RedirectToAction(nameof(this.Students), new { id });
        }

        public async Task<IActionResult> DownloadExam(int id, string studentId)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                return this.BadRequest();
            }

            var userId = this.userManager.GetUserId(User);

            if (!await this.trainers.IsTrainer(id, userId))
            {
                return this.BadRequest();
            }

            var examContents = await this.trainers.GetExamSubmossion(id, studentId);

            if (examContents == null)
            {
                return this.BadRequest();
            }

            var studentInCourseNames = await this.trainers.StudentInCourseNamesAsync(id, userId);

            if (studentInCourseNames == null)
            {
                return this.BadRequest();
            }

            return this.File(examContents, "application/zip", $"{studentInCourseNames.CourseName}-{studentInCourseNames.Username}.zip");
        }
    }
}