namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BusinessUnitTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessUnits",
                c => new
                    {
                        unitId = c.Int(nullable: false, identity: true),
                        unitName = c.String(),
                    })
                .PrimaryKey(t => t.unitId);
            
            AddColumn("dbo.Positions", "BUnit_unitId", c => c.Int());
            CreateIndex("dbo.Positions", "BUnit_unitId");
            AddForeignKey("dbo.Positions", "BUnit_unitId", "dbo.BusinessUnits", "unitId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Positions", "BUnit_unitId", "dbo.BusinessUnits");
            DropIndex("dbo.Positions", new[] { "BUnit_unitId" });
            DropColumn("dbo.Positions", "BUnit_unitId");
            DropTable("dbo.BusinessUnits");
        }
    }
}
