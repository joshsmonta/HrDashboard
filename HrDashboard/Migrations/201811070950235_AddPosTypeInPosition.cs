namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPosTypeInPosition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Positions", "PosType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Positions", "PosType");
        }
    }
}
