namespace _002
{
    using _002.Models;
    using Microsoft.EntityFrameworkCore;

    public class MyDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=.;Database=_002;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne<Department>(a => a.Department)
                .WithMany(a => a.Employees)
                .HasForeignKey(a => a.DepartmentId);
        }
    }
}