namespace Exam
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ExamContext : DbContext
    {
        public ExamContext()
            : base("name=ExamContext")
        {
        }
      
        public virtual DbSet<Agency> Agencys { get; set; }

        public virtual DbSet<Cash> Cashs { get; set; }

        public virtual DbSet<Gift> Gifts { get; set; }

        public virtual DbSet<Invitation> Invitations { get; set; }

        public virtual DbSet<Person> Persons { get; set; }

        public virtual DbSet<Present> Presents { get; set; }

        public virtual DbSet<Venue> Venues { get; set; }

        public virtual DbSet<Wedding> Weddings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Present>()
                .HasKey(a => a.InvitationId);

            modelBuilder.Entity<Invitation>()
                .HasRequired(a => a.Present)
                .WithRequiredPrincipal(s => s.Invitation);

            base.OnModelCreating(modelBuilder);
        }
    }
}