namespace Photo
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class PhotoContext : DbContext
    {    
        public PhotoContext()
            : base("name=PhotoContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotoContext, Configuration>());
        }

        public virtual DbSet<Photographer> Photographers { get; set; }

        public virtual DbSet<Album> Albums { get; set; }

        public virtual DbSet<Picture> Pictures { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }
    }
}