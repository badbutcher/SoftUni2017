namespace ProductsShop
{
    using Models;
    using System.Data.Entity;

    public class ShopContext : DbContext
    {
        public ShopContext()
            : base("name=ShopContext")
        {
            ////Database.SetInitializer(new DropCreateDatabaseAlways<ShopContext>());
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Categorie> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendId");
                    m.ToTable("UserFriends");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}