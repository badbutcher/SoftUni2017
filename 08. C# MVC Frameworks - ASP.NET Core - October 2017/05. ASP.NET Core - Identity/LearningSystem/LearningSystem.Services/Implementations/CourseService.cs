namespace LearningSystem.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using LearningSystem.Data;
    using LearningSystem.Data.Models;
    using LearningSystem.Services.Models;
    using Microsoft.EntityFrameworkCore;

    public class CourseService : ICourseService
    {
        private readonly LearningSystemDbContext db;

        public CourseService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CourseListingServiceModel>> ActiveAsync()
        {
            var result = await this.db.Courses
                .OrderByDescending(a => a.Id)
                .Where(a => a.StartDate <= DateTime.UtcNow)
                .ProjectTo<CourseListingServiceModel>()
                .ToListAsync();

            return result;
        }

        public async Task<TModel> ByIdAsync<TModel>(int id) where TModel : class
        {
            var result = await this.db.Courses
                .Where(a => a.Id == id)
                .ProjectTo<TModel>()
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> SignUpStudentAsync(int courseId, string studentId)
        {
            var courseInfo = await this.GetCourseInfo(courseId, studentId);

            if (courseInfo == null || courseInfo.StartDate < DateTime.UtcNow || courseInfo.UserIsEnrolled)
            {
                return false;
            }

            var studentInCourse = new StudentCourse
            {
                CourseId = courseId,
                StudentId = studentId
            };

            this.db.Add(studentInCourse);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SignOutStudentAsync(int courseId, string studentId)
        {
            var courseInfo = await this.GetCourseInfo(courseId, studentId);

            if (courseInfo == null || courseInfo.StartDate < DateTime.UtcNow || !courseInfo.UserIsEnrolled)
            {
                return false;
            }

            /// mode i taka vmesto tova dolu
            /// var dddd = await this.db.Courses
            ///    .Where(a => a.Id == courseId)
            ///    .SelectMany(a => a.Students)
            ///    .FirstOrDefaultAsync(a => a.StudentId == studentId);

            var studnetInCourse = await this.db
                .FindAsync<StudentCourse>(courseId, studentId);

            this.db.Remove(studnetInCourse);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> StudentIsEnrolledCourseAsync(int courseId, string studentId)
        {
            var result = await this.db.Courses
                .AnyAsync(a => a.Id == courseId && a.Students.Any(c => c.StudentId == studentId));

            return result;
        }

        public async Task<IEnumerable<CourseListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;
            var result = await this.db.Courses
                .OrderByDescending(c => c.Id)
                .Where(c => c.Name.ToLower().Contains(searchText.ToLower()))
                .ProjectTo<CourseListingServiceModel>()
                .ToListAsync();

            return result;
        }

        public async Task<bool> SaveExamSubmission(int courseId, string studentId, byte[] examSubmission)
        {
            var studnetInCourse = await this.db
              .FindAsync<StudentCourse>(courseId, studentId);

            if (studnetInCourse == null)
            {
                return false;
            }

            studnetInCourse.ExamSubmission = examSubmission;
            await this.db.SaveChangesAsync();

            return true;
        }

        private async Task<CourseWithStudentInfo> GetCourseInfo(int courseId, string studentId)
        {
            var courseInfo = await this.db.Courses
                .Where(c => c.Id == courseId)
                .Select(a => new CourseWithStudentInfo
                {
                    StartDate = a.StartDate,
                    UserIsEnrolled = a.Students.Any(d => d.StudentId == studentId)
                }).FirstOrDefaultAsync();

            return courseInfo;
        }
    }
}