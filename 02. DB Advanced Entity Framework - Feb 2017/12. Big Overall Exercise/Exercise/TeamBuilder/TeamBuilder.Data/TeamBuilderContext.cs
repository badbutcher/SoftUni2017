namespace TeamBuilder.Data
{
    using Configurations;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TeamBuilderContext : DbContext
    {
        public TeamBuilderContext()
            : base("name=TeamBuilderContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<TeamBuilderContext>());
        }

        public virtual DbSet<Event> Event { get; set; }

        public virtual DbSet<Invitation> Invitation { get; set; }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new InvitationConfiguration());
            modelBuilder.Configurations.Add(new TeamConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}