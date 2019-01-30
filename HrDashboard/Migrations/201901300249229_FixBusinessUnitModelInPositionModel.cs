namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixBusinessUnitModelInPositionModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Positions", "BUnit_unitId", "dbo.BusinessUnits");
            DropIndex("dbo.Positions", new[] { "BUnit_unitId" });
            RenameColumn(table: "dbo.Positions", name: "BUnit_unitId", newName: "unitId");
            AlterColumn("dbo.Positions", "unitId", c => c.Int(nullable: false));
            CreateIndex("dbo.Positions", "unitId");
            AddForeignKey("dbo.Positions", "unitId", "dbo.BusinessUnits", "unitId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Positions", "unitId", "dbo.BusinessUnits");
            DropIndex("dbo.Positions", new[] { "unitId" });
            AlterColumn("dbo.Positions", "unitId", c => c.Int());
            RenameColumn(table: "dbo.Positions", name: "unitId", newName: "BUnit_unitId");
            CreateIndex("dbo.Positions", "BUnit_unitId");
            AddForeignKey("dbo.Positions", "BUnit_unitId", "dbo.BusinessUnits", "unitId");
        }
    }
}
