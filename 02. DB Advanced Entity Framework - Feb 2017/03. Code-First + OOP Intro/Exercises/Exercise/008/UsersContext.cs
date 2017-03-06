namespace _008
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("name=UsersContext")
        {
        }

        public virtual DbSet<Users> Users { get; set; }
    }
}