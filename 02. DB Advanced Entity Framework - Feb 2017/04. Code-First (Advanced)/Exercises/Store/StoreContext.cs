namespace Store
{
    using System.Data.Entity;

    public class StoreContext : DbContext
    {
        public StoreContext()
            : base("name=StoreContext")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}