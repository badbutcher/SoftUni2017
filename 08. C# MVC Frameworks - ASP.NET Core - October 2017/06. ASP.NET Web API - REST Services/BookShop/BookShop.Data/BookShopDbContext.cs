namespace BookShop.Data
{
    using BookShop.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class BookShopDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Categorie> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=.;Database=BookShopDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CategoryBooks>()
                .HasKey(a => new { a.CategoryId, a.BookId });

            builder.Entity<Categorie>()
                .HasMany(a => a.Books)
                .WithOne(a => a.Categorie)
                .HasForeignKey(a => a.CategoryId);

            builder.Entity<Book>()
                .HasMany(a => a.Categories)
                .WithOne(a => a.Book)
                .HasForeignKey(a => a.BookId);

            builder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId);
        }
    }
}