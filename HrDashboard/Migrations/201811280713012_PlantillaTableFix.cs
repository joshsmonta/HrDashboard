namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlantillaTableFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Plantillas", "AlphaList_Id", "dbo.AlphaLists");
            DropForeignKey("dbo.Plantillas", "Position_PosId", "dbo.Positions");
            DropIndex("dbo.Plantillas", new[] { "AlphaList_Id" });
            DropIndex("dbo.Plantillas", new[] { "Position_PosId" });
            AlterColumn("dbo.Plantillas", "AlphaList_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Plantillas", "Position_PosId", c => c.Int(nullable: false));
            CreateIndex("dbo.Plantillas", "AlphaList_Id");
            CreateIndex("dbo.Plantillas", "Position_PosId");
            AddForeignKey("dbo.Plantillas", "AlphaList_Id", "dbo.AlphaLists", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Plantillas", "Position_PosId", "dbo.Positions", "PosId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plantillas", "Position_PosId", "dbo.Positions");
            DropForeignKey("dbo.Plantillas", "AlphaList_Id", "dbo.AlphaLists");
            DropIndex("dbo.Plantillas", new[] { "Position_PosId" });
            DropIndex("dbo.Plantillas", new[] { "AlphaList_Id" });
            AlterColumn("dbo.Plantillas", "Position_PosId", c => c.Int());
            AlterColumn("dbo.Plantillas", "AlphaList_Id", c => c.Int());
            CreateIndex("dbo.Plantillas", "Position_PosId");
            CreateIndex("dbo.Plantillas", "AlphaList_Id");
            AddForeignKey("dbo.Plantillas", "Position_PosId", "dbo.Positions", "PosId");
            AddForeignKey("dbo.Plantillas", "AlphaList_Id", "dbo.AlphaLists", "Id");
        }
    }
}
