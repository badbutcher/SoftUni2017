namespace Sale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesAddDateDefault : DbMigration
    {
        public override void Up()
        {
            AlterColumn("_Sale", "Date", s => s.String(defaultValueSql: "GETDATE()"));
        }
        
        public override void Down()
        {
            AlterColumn("_Sale", "Date", s => s.String(defaultValueSql: null));
        }
    }
}
