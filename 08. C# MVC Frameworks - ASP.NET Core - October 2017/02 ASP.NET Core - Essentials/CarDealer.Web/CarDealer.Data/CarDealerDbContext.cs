namespace CarDealer.Data
{
    using CarDealer.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class CarDealerDbContext : IdentityDbContext<User>
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PartCar>()
                   .HasKey(a => new { a.PartId, a.CarId });

            builder.Entity<Car>()
                .HasMany(p => p.Parts)
                .WithOne(c => c.Car)
                .HasForeignKey(c => c.CarId);

            builder.Entity<Part>()
                .HasMany(p => p.Cars)
                .WithOne(c => c.Part)
                .HasForeignKey(c => c.PartId);

            builder.Entity<Supplier>()
                .HasMany(p => p.Parts)
                .WithOne(s => s.Supplier)
                .HasForeignKey(s => s.SupplierId);

            builder.Entity<Car>()
                .HasMany(s => s.Sales)
                .WithOne(c => c.Car)
                .HasForeignKey(c => c.CarId);

            builder.Entity<Customer>()
                .HasMany(s => s.Sales)
                .WithOne(c => c.Customer)
                .HasForeignKey(c => c.CustomerId);

            base.OnModelCreating(builder);
        }
    }
}