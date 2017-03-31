namespace Exam
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

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
            base.OnModelCreating(modelBuilder);
        }
    }
}