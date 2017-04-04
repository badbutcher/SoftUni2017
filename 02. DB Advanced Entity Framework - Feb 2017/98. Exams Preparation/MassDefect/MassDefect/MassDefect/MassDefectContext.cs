namespace MassDefect
{
    using Models;
    using System.Data.Entity;

    public class MassDefectContext : DbContext
    {
        public MassDefectContext()
            : base("name=MassDefectContext")
        {
            ////Database.SetInitializer(new DropCreateDatabaseAlways<MassDefectEntities>());
        }

        public virtual DbSet<Anomalie> Anomalies { get; set; }

        public virtual DbSet<Person> Person { get; set; }

        public virtual DbSet<Planet> Planets { get; set; }

        public virtual DbSet<SolarSystem> SolarSystem { get; set; }

        public virtual DbSet<Star> Stars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anomalie>()
                .HasRequired(a => a.OriginPlanet)
                .WithMany(s => s.OriginPlanet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Anomalie>()
                .HasRequired(a => a.TeleportPlanet)
                .WithMany(s => s.TeleportPlanet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Star>()
                .HasRequired(a => a.SolarSystem)
                .WithMany(s => s.Stars)
                .WillCascadeOnDelete(false);

            ////modelBuilder.Entity<Planet>()
            ////   .HasRequired(a => a.Sun)
            ////   .WithMany(s => s.Planets)
            ////   .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(a => a.Anomalies)
                .WithMany(c => c.Victims)
                .Map(ac =>
                {
                    ac.ToTable("AnomalyVictims");
                    ac.MapLeftKey("AnomalyId");
                    ac.MapRightKey("PersonId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}