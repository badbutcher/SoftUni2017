namespace _01Do04.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLicenses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Resources_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resources", t => t.Resources_Id)
                .Index(t => t.Resources_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Licenses", "Resources_Id", "dbo.Resources");
            DropIndex("dbo.Licenses", new[] { "Resources_Id" });
            DropTable("dbo.Licenses");
        }
    }
}
