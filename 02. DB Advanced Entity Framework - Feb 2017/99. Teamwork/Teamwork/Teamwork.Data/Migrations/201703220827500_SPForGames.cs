namespace Teamwork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SPForGames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "IsSingleplayer", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Developers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Developers", "Founded", c => c.DateTime());
            AlterColumn("dbo.Games", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Games", "RelaseDate", c => c.DateTime());
            AlterColumn("dbo.Publishers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Publishers", "Founded", c => c.DateTime());
            AlterColumn("dbo.Reviews", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Reviews", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "Content", c => c.String());
            AlterColumn("dbo.Reviews", "Content", c => c.String());
            AlterColumn("dbo.Reviews", "Name", c => c.String());
            AlterColumn("dbo.Publishers", "Founded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Publishers", "Name", c => c.String());
            AlterColumn("dbo.Games", "RelaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Games", "Name", c => c.String());
            AlterColumn("dbo.Developers", "Founded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Developers", "Name", c => c.String());
            DropColumn("dbo.Games", "IsSingleplayer");
        }
    }
}
