namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ccc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AlphaLists", "Position_PosId", "dbo.Positions");
            DropIndex("dbo.AlphaLists", new[] { "Position_PosId" });
            RenameColumn(table: "dbo.AlphaLists", name: "Position_PosId", newName: "posId");
            AlterColumn("dbo.AlphaLists", "posId", c => c.Int(nullable: false));
            CreateIndex("dbo.AlphaLists", "posId");
            AddForeignKey("dbo.AlphaLists", "posId", "dbo.Positions", "PosId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlphaLists", "posId", "dbo.Positions");
            DropIndex("dbo.AlphaLists", new[] { "posId" });
            AlterColumn("dbo.AlphaLists", "posId", c => c.Int());
            RenameColumn(table: "dbo.AlphaLists", name: "posId", newName: "Position_PosId");
            CreateIndex("dbo.AlphaLists", "Position_PosId");
            AddForeignKey("dbo.AlphaLists", "Position_PosId", "dbo.Positions", "PosId");
        }
    }
}
