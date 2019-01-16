namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAgeYearsOfServiceColumns : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AlphaLists", "YearOfServices");
            DropColumn("dbo.AlphaLists", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AlphaLists", "Age", c => c.Byte(nullable: false));
            AddColumn("dbo.AlphaLists", "YearOfServices", c => c.String(nullable: false));
        }
    }
}
