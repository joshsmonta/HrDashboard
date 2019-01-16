namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileNameToAlphaList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlphaLists", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AlphaLists", "FileName");
        }
    }
}
