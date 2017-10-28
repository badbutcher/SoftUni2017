namespace Exam.App.Data
{
    using Exam.App.Data.Model;
    using Microsoft.EntityFrameworkCore;

    public class ExamDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=.;Database=ExamDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<User>()
                .HasMany(t => t.Posts)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);
        }
    }
}