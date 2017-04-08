namespace _01.CodeFirst
{
    using Models;
    using System.Data.Entity;

    public class ExamContext : DbContext
    {
        public ExamContext()
            : base("name=ExamContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<ExamContext>());
        }

        public virtual DbSet<Anomalie> Anomalies { get; set; }

        public virtual DbSet<Person> Persons { get; set; }

        public virtual DbSet<Planet> Planets { get; set; }

        public virtual DbSet<SolarSystem> SolarSystems { get; set; }

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

            modelBuilder.Entity<Person>()
                .HasMany(a => a.Anomalies)
                .WithMany(s => s.Victims)
                .Map(ss =>
                {
                    ss.ToTable("AnomalyVictims");
                    ss.MapLeftKey("AnomalyId");
                    ss.MapRightKey("PersonId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}