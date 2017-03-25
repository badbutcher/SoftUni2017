namespace Teamwork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Location = c.String(),
                        Founded = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsSingleplayer = c.Boolean(nullable: false),
                        IsMultiplayer = c.Boolean(nullable: false),
                        RelaseDate = c.DateTime(nullable: false, defaultValueSql: null),
                        GameGenre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Location = c.String(),
                        Founded = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        Rating = c.Single(nullable: false),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        ReviewId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reviews", t => t.ReviewId, cascadeDelete: true)
                .Index(t => t.ReviewId);
            
            CreateTable(
                "dbo.GameDevelopers",
                c => new
                    {
                        Game_Id = c.Int(nullable: false),
                        Developer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Game_Id, t.Developer_Id })
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .ForeignKey("dbo.Developers", t => t.Developer_Id, cascadeDelete: true)
                .Index(t => t.Game_Id)
                .Index(t => t.Developer_Id);
            
            CreateTable(
                "dbo.PublisherGames",
                c => new
                    {
                        Publisher_Id = c.Int(nullable: false),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Publisher_Id, t.Game_Id })
                .ForeignKey("dbo.Publishers", t => t.Publisher_Id, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .Index(t => t.Publisher_Id)
                .Index(t => t.Game_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "GameId", "dbo.Games");
            DropForeignKey("dbo.Comments", "ReviewId", "dbo.Reviews");
            DropForeignKey("dbo.PublisherGames", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.PublisherGames", "Publisher_Id", "dbo.Publishers");
            DropForeignKey("dbo.GameDevelopers", "Developer_Id", "dbo.Developers");
            DropForeignKey("dbo.GameDevelopers", "Game_Id", "dbo.Games");
            DropIndex("dbo.PublisherGames", new[] { "Game_Id" });
            DropIndex("dbo.PublisherGames", new[] { "Publisher_Id" });
            DropIndex("dbo.GameDevelopers", new[] { "Developer_Id" });
            DropIndex("dbo.GameDevelopers", new[] { "Game_Id" });
            DropIndex("dbo.Comments", new[] { "ReviewId" });
            DropIndex("dbo.Reviews", new[] { "GameId" });
            DropTable("dbo.PublisherGames");
            DropTable("dbo.GameDevelopers");
            DropTable("dbo.Comments");
            DropTable("dbo.Reviews");
            DropTable("dbo.Publishers");
            DropTable("dbo.Games");
            DropTable("dbo.Developers");
        }
    }
}
