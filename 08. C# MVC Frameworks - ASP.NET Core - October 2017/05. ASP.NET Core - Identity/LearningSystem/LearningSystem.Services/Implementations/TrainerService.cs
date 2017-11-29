namespace LearningSystem.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using LearningSystem.Data;
    using LearningSystem.Data.Models;
    using LearningSystem.Services.Models;
    using Microsoft.EntityFrameworkCore;

    public class TrainerService : ITrainerService
    {
        private readonly LearningSystemDbContext db;

        public TrainerService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddGradeAsync(int courseId, string studentId, Grade grade)
        {
            var studentInCourse = await this.db.FindAsync<StudentCourse>(courseId, studentId);

            if (studentInCourse == null)
            {
                return false;
            }

            studentInCourse.Grade = grade;
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CourseListingServiceModel>> CoursesAsync(string trainerId)
        {
            var result = await this.db.Courses
                .Where(c => c.TrainerId == trainerId)
                .ProjectTo<CourseListingServiceModel>()
                .ToListAsync();

            return result;
        }

        ////public async Task<byte[]> GetExamSubmossion(int courseId, string studentId)
        ////{
        ////    var studentInCourse = await this.db.FindAsync<StudentCourse>(courseId, studentId);

        ////    if (studentInCourse == null)
        ////    {
        ////        return null;
        ////    }

        ////    return studentInCourse.ExamSubmission;
        ////}

        ////VVVV edno i su6to

        public async Task<byte[]> GetExamSubmossion(int courseId, string studentId)
            => (await this.db.FindAsync<StudentCourse>(courseId, studentId))?.ExamSubmission;

        public async Task<bool> IsTrainer(int courseId, string trainerId)
        {
            var result = await this.db.Courses.AnyAsync(c => c.Id == courseId && c.TrainerId == trainerId);

            return result;
        }

        public async Task<IEnumerable<StudnetInCourseServiceModel>> StudentInCourseAsync(int courseId)
        {
            var result = await this.db.Courses.Where(c => c.Id == courseId)
                .SelectMany(c => c.Students.Select(s => s.Student))
                .ProjectTo<StudnetInCourseServiceModel>(new { courseId }).ToListAsync();

            return result;
        }

        public async Task<StudentInCourseNamesServiceModel> StudentInCourseNamesAsync(int courseId, string studentId)
        {
            var username = await this.db.Users
                .Where(a => a.Id == studentId)
                .Select(a => a.UserName)
                .FirstOrDefaultAsync();

            if (username == null)
            {
                return null;
            }

            var courseName = await this.db.Courses
                .Where(a => a.Id == courseId)
                .Select(a => a.Name)
                .FirstOrDefaultAsync();

            if (courseName == null)
            {
                return null;
            }

            return new StudentInCourseNamesServiceModel
            {
                Username = username,
                CourseName = courseName
            };
        }
    }
}