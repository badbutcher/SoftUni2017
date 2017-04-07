namespace Exam
{
    using Models;
    using System.Data.Entity;

    public class PhotoContext : DbContext
    {
        public PhotoContext()
            : base("name=PhotoContext")
        {
        }

        public virtual DbSet<Accessory> Accessorys { get; set; }

        public virtual DbSet<Camera> Cameras { get; set; }

        public virtual DbSet<DslrCamera> DslrCameras { get; set; }

        public virtual DbSet<Lens> Lenses { get; set; }

        public virtual DbSet<MirrorlessCamera> MirrorlessCameras { get; set; }

        public virtual DbSet<Photographer> Photographers { get; set; }

        public virtual DbSet<Workshop> Workshops { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ////modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Photographer>()
                    .HasRequired(a => a.PrimaryCamera)
                    .WithMany(b => b.PrimaryCamerasPhotographers)
                    .HasForeignKey(d => d.PrimaryCameraId)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Photographer>()
                 .HasRequired(a => a.SecondaryCamera)
                 .WithMany(b => b.SecondaryCamerasPhotographers)
                 .HasForeignKey(d => d.SecondaryCameraId)
                 .WillCascadeOnDelete(false);

            modelBuilder.Entity<Photographer>()
                .HasMany(p => p.WorkshopsParticipated)
                .WithMany(w => w.Participants)
                .Map(pw =>
                {
                    pw.ToTable("Enrollment");
                    pw.MapLeftKey("WorkshopId");
                    pw.MapRightKey("PhotographerId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}