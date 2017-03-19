namespace PhotoShare.Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    using Client;
    using Models;

    internal class Configuration : DbMigrationsConfiguration<PhotoShareContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhotoShareContext context)
        {
        }
    }
}
