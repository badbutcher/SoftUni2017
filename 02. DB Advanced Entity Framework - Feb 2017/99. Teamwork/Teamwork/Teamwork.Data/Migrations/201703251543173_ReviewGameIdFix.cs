namespace Teamwork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewGameIdFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "GameId", "dbo.Games");
            DropIndex("dbo.Reviews", new[] { "GameId" });
            AlterColumn("dbo.Reviews", "GameId", c => c.Int());
            CreateIndex("dbo.Reviews", "GameId");
            AddForeignKey("dbo.Reviews", "GameId", "dbo.Games", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "GameId", "dbo.Games");
            DropIndex("dbo.Reviews", new[] { "GameId" });
            AlterColumn("dbo.Reviews", "GameId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviews", "GameId");
            AddForeignKey("dbo.Reviews", "GameId", "dbo.Games", "Id", cascadeDelete: true);
        }
    }
}
