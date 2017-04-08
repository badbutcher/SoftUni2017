namespace _01.CodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ExamContext : DbContext
    {
        public ExamContext()
            : base("name=ExamContext")
        {
        }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
}