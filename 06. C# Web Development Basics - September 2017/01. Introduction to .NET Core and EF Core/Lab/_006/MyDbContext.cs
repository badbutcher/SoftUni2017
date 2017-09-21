namespace _006
{
    using _006.Models;
    using Microsoft.EntityFrameworkCore;

    public class MyDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Salesman> Salesmans { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=.;Database=_006;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(a => a.Salesman)
                .WithMany(a => a.Customers)
                .HasForeignKey(a => a.SalesmanId);

            modelBuilder.Entity<Order>()
                .HasOne(a => a.Customer)
                .WithMany(a => a.Orders)
                .HasForeignKey(a => a.CustomerId);

            modelBuilder.Entity<Review>()
                .HasOne(a => a.Customer)
                .WithMany(a => a.Reviews)
                .HasForeignKey(a => a.CustomerId);
        }
    }
}