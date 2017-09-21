namespace _004
{
    using _004.Models;
    using _004.Models.ManyToMany;
    using Microsoft.EntityFrameworkCore;

    public class MyDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=.;Database=_004;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentsCourses>()
                .HasKey(a => new { a.StudentId, a.CourseId });

            modelBuilder.Entity<StudentsCourses>()
                .HasOne<Student>(a => a.Student)
                .WithMany(a => a.StudentsCourses)
                .HasForeignKey(a => a.StudentId);

            modelBuilder.Entity<StudentsCourses>()
               .HasOne<Course>(a => a.Course)
               .WithMany(a => a.StudentsCourses)
               .HasForeignKey(a => a.CourseId);
        }
    }
}