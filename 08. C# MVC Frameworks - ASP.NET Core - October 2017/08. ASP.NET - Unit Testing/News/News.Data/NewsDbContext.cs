namespace News.Data
{
    using Microsoft.EntityFrameworkCore;

    public class NewsDbContext : DbContext
    {
        public DbSet<News> News { get; set; }

        public NewsDbContext(DbContextOptions<NewsDbContext> builder)
            :base(builder)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    builder.UseSqlServer("Server=.;Database=NewsDb;Integrated Security=True;");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}