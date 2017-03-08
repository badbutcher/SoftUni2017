namespace _01Do04
{
    using System.Data.Entity;
    using Models;
    using Migrations;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("name=StudentSystemContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());
        }

        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Homework> Homework { get; set; }
        public virtual DbSet<Resources> Resources { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<License> Licenses { get; set; }
    }
}