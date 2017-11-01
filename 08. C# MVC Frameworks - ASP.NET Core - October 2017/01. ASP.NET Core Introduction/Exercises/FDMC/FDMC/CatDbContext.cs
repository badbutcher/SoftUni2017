namespace FDMC
{
    using Microsoft.EntityFrameworkCore;

    public class CatDbContext : DbContext
    {
        public CatDbContext(DbContextOptions<CatDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; }
    }
}