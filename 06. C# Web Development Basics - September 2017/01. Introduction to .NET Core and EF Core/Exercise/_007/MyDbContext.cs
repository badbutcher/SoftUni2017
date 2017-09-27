namespace _007
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using _007.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Friendship> Friendship { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=.;Database=_007;Integrated Security=True;");
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

            modelBuilder.Entity<AlbumTag>()
               .HasKey(a => new { a.TagId, a.AlbumId });

            modelBuilder.Entity<Picture>()
                .HasMany(a => a.Albums)
                .WithOne(a => a.Picture)
                .HasForeignKey(a => a.PictureId);

            modelBuilder.Entity<Tag>()
                .HasMany(a => a.Albums)
                .WithOne(a => a.Tag)
                .HasForeignKey(a => a.TagId);

            modelBuilder.Entity<Album>()
               .HasMany(a => a.Tags)
               .WithOne(a => a.Album)
               .HasForeignKey(a => a.AlbumId);
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