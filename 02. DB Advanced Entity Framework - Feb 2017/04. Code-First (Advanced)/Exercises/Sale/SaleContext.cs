namespace Sale
{
    using System.Data.Entity;
    using Models;

    public class SaleContext : DbContext
    {
        public SaleContext()
            : base("name=SaleContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SaleContext>());
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<StoreLocation> StoreLocations { get; set; }

        public virtual DbSet<_Sale> Sales { get; set; }
    }
}