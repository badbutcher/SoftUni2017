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

    public class UserService : IUserService
    {
        private readonly LearningSystemDbContext db;
        private readonly IPdfGenerator pdfGenerator;

        public UserService(LearningSystemDbContext db, IPdfGenerator pdfGenerator)
        {
            this.db = db;
            this.pdfGenerator = pdfGenerator;
        }

        public async Task<IEnumerable<UserListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;
            var result = await this.db.Users
                .OrderBy(a => a.UserName)
                .Where(a => a.Name.ToLower().Contains(searchText.ToLower()))
                .ProjectTo<UserListingServiceModel>()
                .ToListAsync();

            return result;
        }

        public async Task<UserProfileServiceModel> ProfileAsync(string id)
        {
            var result = await this.db.Users
                .Where(a => a.Id == id)
                .ProjectTo<UserProfileServiceModel>(new { studentId = id })
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<byte[]> GetPdfCertificate(int courseId, string studentId)
        {
            var studentInCourse = await this.db
                .FindAsync<StudentCourse>(courseId, studentId);

            if (studentInCourse == null)
            {
                return null;
            }

            var certificateInfo = await this.db.Courses
                .Where(a => a.Id == courseId)
                .Select(a => new
                {
                    CourseName = a.Name,
                    CourseStartDate = a.StartDate,
                    CourseEndDate = a.EndDate,
                    StudentName = a.Students
                        .Where(c => c.StudentId == studentId)
                        .Select(c => c.Student.Name)
                        .FirstOrDefault(),
                    StudentGrade = a.Students
                        .Where(c => c.StudentId == studentId)
                        .Select(c => c.Grade)
                        .FirstOrDefault(),
                    Trainer = a.Trainer.Name
                }).FirstOrDefaultAsync();

            return this.pdfGenerator.GeneratePdfFromHtml(
                string.Format(ServiceConstats.PDfCertificateFormat,
                certificateInfo.CourseName,
                certificateInfo.CourseStartDate.ToShortDateString(),
                certificateInfo.CourseEndDate.ToShortDateString(),
                certificateInfo.StudentName,
                certificateInfo.StudentGrade,
                certificateInfo.Trainer,
                DateTime.UtcNow.ToShortDateString()));
        }
    }
}