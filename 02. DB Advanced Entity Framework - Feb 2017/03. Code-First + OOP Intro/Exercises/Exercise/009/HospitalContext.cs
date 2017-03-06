namespace _009
{
    using System.Data.Entity;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
            : base("name=HospitalContext")
        {
        }

        public virtual DbSet<Patients> Patients { get; set; }

        public virtual DbSet<Diagnoses> Diagnoses { get; set; }

        public virtual DbSet<PrescribedMedicaments> PrescribedMedicaments { get; set; }

        public virtual DbSet<Visitations> Visitations { get; set; }
    }
}