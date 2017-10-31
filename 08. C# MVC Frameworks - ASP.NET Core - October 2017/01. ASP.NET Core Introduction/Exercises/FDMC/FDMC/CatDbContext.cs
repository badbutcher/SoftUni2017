namespace FDMC
{
    using Microsoft.EntityFrameworkCore;

    public class CatDbContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }
    }
}