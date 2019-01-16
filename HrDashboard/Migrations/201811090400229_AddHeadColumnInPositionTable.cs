namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHeadColumnInPositionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Positions", "Head", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Positions", "Head");
        }
    }
}
