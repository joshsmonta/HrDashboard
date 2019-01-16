namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectPositionsToAlphaList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlphaLists", "Position_PosId", c => c.Int());
            CreateIndex("dbo.AlphaLists", "Position_PosId");
            AddForeignKey("dbo.AlphaLists", "Position_PosId", "dbo.Positions", "PosId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlphaLists", "Position_PosId", "dbo.Positions");
            DropIndex("dbo.AlphaLists", new[] { "Position_PosId" });
            DropColumn("dbo.AlphaLists", "Position_PosId");
        }
    }
}
