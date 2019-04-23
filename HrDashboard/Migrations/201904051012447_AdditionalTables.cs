namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeUsers",
                c => new
                    {
                        EmpId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        EmpUsername = c.String(),
                        EmpPassword = c.String(),
                        EmpConfirmPassword = c.String(),
                        Email = c.String(),
                        IsEmailVerified = c.Boolean(nullable: false),
                        ActivationCode = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EmpId);
            
            CreateTable(
                "dbo.SRFRequests",
                c => new
                    {
                        ReqId = c.Int(nullable: false, identity: true),
                        ReqPosition = c.String(),
                        PosDiv = c.String(),
                        PosDept = c.String(),
                        PosSect = c.String(),
                        Quantity = c.Int(nullable: false),
                        PersonToReplace = c.String(),
                        Temporary = c.Boolean(nullable: false),
                        DurationInYears = c.Int(nullable: false),
                        DurationInMonths = c.Int(nullable: false),
                        RequestedBy = c.String(),
                        ReviewedBy = c.String(),
                        Reviewed = c.Boolean(nullable: false),
                        ApprovedBy = c.String(),
                        Approved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReqId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SRFRequests");
            DropTable("dbo.EmployeeUsers");
        }
    }
}
