namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBusinessUnitInPositionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Positions", "BusinessUnit", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Positions", "BusinessUnit");
        }
    }
}
