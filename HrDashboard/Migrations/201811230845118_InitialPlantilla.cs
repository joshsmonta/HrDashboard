namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialPlantilla : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Plantillas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DivId = c.Int(nullable: false),
                        DeptId = c.Int(nullable: false),
                        SectId = c.Int(nullable: false),
                        AlphaList_Id = c.Int(nullable: false),
                        Position_PosId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AlphaLists", t => t.AlphaList_Id, cascadeDelete: false)
                .ForeignKey("dbo.Positions", t => t.Position_PosId, cascadeDelete: false)
                .Index(t => t.AlphaList_Id)
                .Index(t => t.Position_PosId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plantillas", "Position_PosId", "dbo.Positions");
            DropForeignKey("dbo.Plantillas", "AlphaList_Id", "dbo.AlphaLists");
            DropIndex("dbo.Plantillas", new[] { "Position_PosId" });
            DropIndex("dbo.Plantillas", new[] { "AlphaList_Id" });
            DropTable("dbo.Plantillas");
        }
    }
}
