using _004.Models;
using Microsoft.EntityFrameworkCore;

namespace _004
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=.;Database=_004;Integrated Security=True;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //}
    }
}