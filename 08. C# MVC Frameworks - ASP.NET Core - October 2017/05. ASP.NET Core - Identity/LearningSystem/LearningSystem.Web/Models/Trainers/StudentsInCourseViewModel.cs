namespace LearningSystem.Web.Models.Trainers
{
    using System.Collections.Generic;
    using LearningSystem.Services.Models;

    public class StudentsInCourseViewModel
    {
        public IEnumerable<StudnetInCourseServiceModel> Students { get; set; }

        public CourseListingServiceModel Course { get; set; }
    }
}