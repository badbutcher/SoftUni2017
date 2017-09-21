namespace _003
{
    using _003.Models;
    using Microsoft.EntityFrameworkCore;

    public class MyDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=.;Database=_003;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne<Department>(a => a.Department)
                .WithMany(a => a.Employees)
                .HasForeignKey(a => a.DepartmentId);

            modelBuilder.Entity<Employee>()
                .HasOne<Employee>(a => a.Manager)
                .WithMany(a => a.Employees)
                .HasForeignKey(a => a.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}