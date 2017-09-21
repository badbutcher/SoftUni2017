namespace _009
{
    using _009.Models;
    using _009.Models.ManyToMany;
    using Microsoft.EntityFrameworkCore;

    public class MyDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Salesman> Salesmans { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=.;Database=_009;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemOrder>()
                .HasKey(a => new { a.ItemId, a.OrderId });

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

            modelBuilder.Entity<Item>()
                .HasMany(a => a.Orders)
                .WithOne(a => a.Item)
                .HasForeignKey(a => a.ItemId);

            modelBuilder.Entity<Order>()
                .HasMany(a => a.Items)
                .WithOne(a => a.Order)
                .HasForeignKey(a => a.OrderId);

            modelBuilder.Entity<Item>()
                .HasMany(a => a.Reviews)
                .WithOne(a => a.Item)
                .HasForeignKey(a => a.ItemId);
        }
    }
}