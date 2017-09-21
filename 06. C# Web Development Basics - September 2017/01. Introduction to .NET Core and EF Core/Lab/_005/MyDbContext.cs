namespace _005
{
    using _005.Models;
    using Microsoft.EntityFrameworkCore;

    public class MyDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Salesman> Salesmans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=.;Database=_005;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(a => a.Salesman)
                .WithMany(a => a.Customers)
                .HasForeignKey(a => a.SalesmanId);
        }
    }
}