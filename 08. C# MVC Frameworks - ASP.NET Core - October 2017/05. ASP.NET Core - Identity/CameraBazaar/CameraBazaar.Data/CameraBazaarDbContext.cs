namespace CameraBazaar.Data
{
    using CameraBazaar.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class CameraBazaarDbContext : IdentityDbContext<User>
    {
        public DbSet<Camera> Cameras { get; set; }

        public CameraBazaarDbContext(DbContextOptions<CameraBazaarDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(a => a.Cameras)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            base.OnModelCreating(builder);
        }
    }
}