namespace LearningSystem.Data
{
    using LearningSystem.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class LearningSystemDbContext : IdentityDbContext<User>
    {
        public LearningSystemDbContext(DbContextOptions<LearningSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentCourse>()
                   .HasKey(a => new { a.CourseId, a.StudentId });

            builder.Entity<StudentCourse>()
                .HasOne(a => a.Student)
                .WithMany(a => a.Courses)
                .HasForeignKey(a => a.StudentId);

            builder.Entity<StudentCourse>()
                .HasOne(a => a.Course)
                .WithMany(a => a.Students)
                .HasForeignKey(a => a.CourseId);

            builder.Entity<Course>()
                .HasOne(a => a.Trainer)
                .WithMany(a => a.Trainings)
                .HasForeignKey(a => a.TrainerId);

            builder.Entity<Article>()
                .HasOne(a => a.Author)
                .WithMany(a => a.Articles)
                .HasForeignKey(a => a.AuthorId);

            base.OnModelCreating(builder);
        }
    }
}