namespace _002
{
    using _002.Models;
    using _002.Models.ManyToMany;
    using Microsoft.EntityFrameworkCore;

    public class MyDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=.;Database=_002;Integrated Security=True;");

            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(c => new { c.CourseId, c.StudentId });

            modelBuilder.Entity<Student>()
                .HasMany(a => a.Courses)
                .WithOne(a => a.Student)
                .HasForeignKey(a => a.StudentId);

            modelBuilder.Entity<Course>()
                .HasMany(a => a.Students)
                .WithOne(a => a.Course)
                .HasForeignKey(a => a.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany(a => a.Resources)
                .WithOne(a => a.Course)
                .HasForeignKey(a => a.CourseId);

            modelBuilder.Entity<Course>()
               .HasMany(a => a.Homeworks)
               .WithOne(a => a.Course)
               .HasForeignKey(a => a.CourseId);

            modelBuilder.Entity<Homework>()
                .HasOne(a => a.Student)
                .WithMany(a => a.Homeworks)
                .HasForeignKey(a => a.StudentId);
        }
    }
}