namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDivisionDeptSectionInAlphaList : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AlphaLists", "Section");
            DropColumn("dbo.AlphaLists", "Department");
            DropColumn("dbo.AlphaLists", "Division");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AlphaLists", "Division", c => c.String(nullable: false));
            AddColumn("dbo.AlphaLists", "Department", c => c.String(nullable: false));
            AddColumn("dbo.AlphaLists", "Section", c => c.String(nullable: false));
        }
    }
}
