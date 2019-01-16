namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusToAlphalist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlphaLists", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AlphaLists", "Active");
        }
    }
}
