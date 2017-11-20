namespace LearningSystem.Services.Models.Course
{
    using System;

    public class AllCourseDataModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Trainer { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}