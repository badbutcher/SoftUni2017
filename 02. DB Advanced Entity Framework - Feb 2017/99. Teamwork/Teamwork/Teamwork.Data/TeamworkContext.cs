namespace Teamwork.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class TeamworkContext : DbContext
    {
        public TeamworkContext()
            : base("name=TeamworkContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TeamworkContext, Configuration>());
        }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Developer> Developers { get; set; }

        public virtual DbSet<Publisher> Publishers { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }
    }
}