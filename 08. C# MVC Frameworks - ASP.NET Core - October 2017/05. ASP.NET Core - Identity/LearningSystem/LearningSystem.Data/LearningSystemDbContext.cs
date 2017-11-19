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
            builder.Entity<UserCourse>()
                .HasKey(a => new { a.CourseId, a.UserId });

            builder.Entity<User>()
                .HasMany(a => a.Courses)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            builder.Entity<Course>()
                .HasMany(a => a.Students)
                .WithOne(a => a.Course)
                .HasForeignKey(a => a.CourseId);

            builder.Entity<User>()
                .HasMany(a => a.Articles)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId);

            base.OnModelCreating(builder);
        }
    }
}