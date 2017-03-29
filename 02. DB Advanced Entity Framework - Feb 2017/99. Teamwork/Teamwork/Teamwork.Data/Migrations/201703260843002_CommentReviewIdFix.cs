namespace Teamwork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentReviewIdFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "ReviewId", "dbo.Reviews");
            DropIndex("dbo.Comments", new[] { "ReviewId" });
            AlterColumn("dbo.Comments", "ReviewId", c => c.Int());
            CreateIndex("dbo.Comments", "ReviewId");
            AddForeignKey("dbo.Comments", "ReviewId", "dbo.Reviews", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ReviewId", "dbo.Reviews");
            DropIndex("dbo.Comments", new[] { "ReviewId" });
            AlterColumn("dbo.Comments", "ReviewId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "ReviewId");
            AddForeignKey("dbo.Comments", "ReviewId", "dbo.Reviews", "Id", cascadeDelete: true);
        }
    }
}
