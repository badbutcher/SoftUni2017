namespace Exam.App.Data
{
    using Exam.App.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ExamDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Contest> Contests { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer($"Server=.;Database=BB_DB_Exam;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<User>()
                .HasMany(a => a.Contests)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
                .HasMany(a => a.Submissions)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Submission>()
                .HasMany(a => a.Contests)
                .WithOne(a => a.Submission)
                .HasForeignKey(a => a.SubmissionId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}