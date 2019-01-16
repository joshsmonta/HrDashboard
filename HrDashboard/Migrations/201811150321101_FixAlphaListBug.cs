namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixAlphaListBug : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AlphaLists", new[] { "posId" });
            CreateIndex("dbo.AlphaLists", "PosId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AlphaLists", new[] { "PosId" });
            CreateIndex("dbo.AlphaLists", "posId");
        }
    }
}
