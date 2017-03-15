namespace Test
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TestContext : DbContext
    {
        
        public TestContext()
            : base("name=TestContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<TestContext>());
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Developer> Developers { get; set; }
        public virtual DbSet<Ost> Osts { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
    }
}