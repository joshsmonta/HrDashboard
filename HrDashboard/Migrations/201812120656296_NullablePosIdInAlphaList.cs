namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullablePosIdInAlphaList : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AlphaLists", "PosId", "dbo.Positions");
            DropIndex("dbo.AlphaLists", new[] { "PosId" });
            AlterColumn("dbo.AlphaLists", "PosId", c => c.Int());
            CreateIndex("dbo.AlphaLists", "PosId");
            AddForeignKey("dbo.AlphaLists", "PosId", "dbo.Positions", "PosId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlphaLists", "PosId", "dbo.Positions");
            DropIndex("dbo.AlphaLists", new[] { "PosId" });
            AlterColumn("dbo.AlphaLists", "PosId", c => c.Int(nullable: false));
            CreateIndex("dbo.AlphaLists", "PosId");
            AddForeignKey("dbo.AlphaLists", "PosId", "dbo.Positions", "PosId", cascadeDelete: true);
        }
    }
}
