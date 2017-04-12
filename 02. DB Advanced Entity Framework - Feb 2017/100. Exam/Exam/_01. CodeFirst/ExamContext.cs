namespace _01.CodeFirst
{
    using System.Data.Entity;
    using Models;

    public class ExamContext : DbContext
    {
        public ExamContext()
            : base("name=ExamContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<ExamContext>());
        }

        public virtual DbSet<Astronomer> Astronomers { get; set; }

        public virtual DbSet<Discovery> Discoveries { get; set; }

        public virtual DbSet<Planet> Planet { get; set; }

        public virtual DbSet<Star> Stars { get; set; }

        public virtual DbSet<StarSystem> StarSystems { get; set; }

        public virtual DbSet<Telescope> Telescopes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Astronomer>()
                .HasMany(a => a.PioneeringDiscoveries)
                .WithMany(s => s.Pioneers)
                .Map(ss =>
                {
                    ss.ToTable("PioneersDiscoveries");
                    ss.MapLeftKey("PieonnerId");
                    ss.MapRightKey("DiscoveryId");
                });

            modelBuilder.Entity<Astronomer>()
                .HasMany(a => a.ObservationsOfDiscoveries)
                .WithMany(s => s.Observers)
                .Map(ss =>
                {
                    ss.ToTable("ObserversDiscoveries");
                    ss.MapLeftKey("ObserverId");
                    ss.MapRightKey("DiscoveryId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}