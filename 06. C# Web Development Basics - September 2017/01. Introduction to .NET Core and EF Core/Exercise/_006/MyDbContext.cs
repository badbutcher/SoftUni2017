namespace _006
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using _006.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Friendship> Friendship { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=.;Database=_006;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friendship>()
                .HasKey(a => new { a.FromUserId, a.ToUserId });

            modelBuilder.Entity<User>()
                .HasMany(a => a.FromFriends)
                .WithOne(a => a.FromUser)
                .HasForeignKey(a => a.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(a => a.ToFriends)
                .WithOne(a => a.ToUser)
                .HasForeignKey(a => a.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AlbumPicture>()
               .HasKey(a => new { a.AlbumId, a.PictureId });

            modelBuilder.Entity<Album>()
                .HasMany(a => a.Pictures)
                .WithOne(a => a.Album)
                .HasForeignKey(a => a.AlbumId);

            modelBuilder.Entity<Album>()
                .HasOne(a => a.User)
                .WithMany(a => a.Albums)
                .HasForeignKey(a => a.UserId);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            var serviceProvider = this.GetService<IServiceProvider>();
            var items = new Dictionary<object, object>();
            foreach (var entry in this.ChangeTracker.Entries().Where(e => (e.State == EntityState.Added) || (e.State == EntityState.Modified)))
            {
                var entity = entry.Entity;
                var context = new ValidationContext(entity, serviceProvider, items);
                var results = new List<ValidationResult>();
                if (Validator.TryValidateObject(entity, context, results, true) == false)
                {
                    foreach (var result in results)
                    {
                        if (result != ValidationResult.Success)
                        {
                            throw new ValidationException(result.ErrorMessage);
                        }
                    }
                }
            }

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
    }
}