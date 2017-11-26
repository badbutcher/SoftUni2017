namespace LearningSystem.Web.Models.Courses
{
    using LearningSystem.Services.Models;

    public class CourseDetailsViewModel
    {
        public CourseDetailsServiceModel Course { get; set; }

        public bool UserIsEnrolledCourse { get; set; }
    }
}