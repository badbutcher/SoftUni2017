namespace Teamwork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentDBSet : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GameDevelopers", newName: "DeveloperGames");
            DropPrimaryKey("dbo.DeveloperGames");
            AddPrimaryKey("dbo.DeveloperGames", new[] { "Developer_Id", "Game_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.DeveloperGames");
            AddPrimaryKey("dbo.DeveloperGames", new[] { "Game_Id", "Developer_Id" });
            RenameTable(name: "dbo.DeveloperGames", newName: "GameDevelopers");
        }
    }
}
