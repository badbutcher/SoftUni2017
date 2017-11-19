namespace LearningSystem.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LearningSystem.Data;
    using LearningSystem.Data.Models;
    using LearningSystem.Services.Contracts;
    using LearningSystem.Services.Models;

    public class CourseService : ICourseService
    {
        private readonly LearningSystemDbContext db;

        public CourseService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public void Add(string name, string description, string trainerId, DateTime startDate, DateTime endDate)
        {
            Course course = new Course()
            {
                Name = name,
                Description = description,
                TrainerId = trainerId,
                StartDate = startDate,
                EndDate = endDate
            };

            this.db.Courses.Add(course);
            this.db.SaveChanges();
        }

        public IEnumerable<AllCourseDataModel> All()
        {
            var result = this.db.Courses
                .Select(a => new AllCourseDataModel
                {
                    Name = a.Name,
                    Description = a.Description,
                    Trainer = a.Trainer.Name,
                    StartDate = a.StartDate,
                    EndDate = a.EndDate
                })
                .OrderByDescending(a => a.StartDate).ToList();

            return result;
        }
    }
}