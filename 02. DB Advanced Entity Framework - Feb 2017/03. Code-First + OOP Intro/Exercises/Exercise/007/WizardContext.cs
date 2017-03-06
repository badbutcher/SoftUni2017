namespace _007
{
    using System.Data.Entity;

    public class WizardContext : DbContext
    {
        public WizardContext()
            : base("name=WizardContext")
        {
        }

        public virtual DbSet<WizardDeposits> WizardDeposits { get; set; }
    }
}