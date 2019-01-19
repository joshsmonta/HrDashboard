namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalColumnsInBetaList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BetaLists", "InitStatRemarks", c => c.String());
            AddColumn("dbo.BetaLists", "HrRemarks", c => c.String());
            AddColumn("dbo.BetaLists", "ExamRemarks", c => c.String());
            AddColumn("dbo.BetaLists", "DeptRemarks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BetaLists", "DeptRemarks");
            DropColumn("dbo.BetaLists", "ExamRemarks");
            DropColumn("dbo.BetaLists", "HrRemarks");
            DropColumn("dbo.BetaLists", "InitStatRemarks");
        }
    }
}
