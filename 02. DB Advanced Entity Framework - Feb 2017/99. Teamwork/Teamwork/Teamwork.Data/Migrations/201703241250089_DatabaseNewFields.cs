namespace Teamwork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseNewFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Developers", "FoundedInCountryName", c => c.String());
            AddColumn("dbo.Developers", "FoundedInCityName", c => c.String());
            AddColumn("dbo.Developers", "DateFounded", c => c.DateTime());
            AddColumn("dbo.Publishers", "FoundedInCountryName", c => c.String());
            AddColumn("dbo.Publishers", "FoundedInCityName", c => c.String());
            AddColumn("dbo.Publishers", "FoundedIn", c => c.DateTime());
            DropColumn("dbo.Developers", "Location");
            DropColumn("dbo.Developers", "Founded");
            DropColumn("dbo.Publishers", "Location");
            DropColumn("dbo.Publishers", "Founded");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Publishers", "Founded", c => c.DateTime());
            AddColumn("dbo.Publishers", "Location", c => c.String());
            AddColumn("dbo.Developers", "Founded", c => c.DateTime());
            AddColumn("dbo.Developers", "Location", c => c.String());
            DropColumn("dbo.Publishers", "FoundedIn");
            DropColumn("dbo.Publishers", "FoundedInCityName");
            DropColumn("dbo.Publishers", "FoundedInCountryName");
            DropColumn("dbo.Developers", "DateFounded");
            DropColumn("dbo.Developers", "FoundedInCityName");
            DropColumn("dbo.Developers", "FoundedInCountryName");
        }
    }
}
