namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlphaLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfHire = c.DateTime(nullable: false),
                        YearOfServices = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Age = c.Byte(nullable: false),
                        Sex = c.String(nullable: false),
                        CivilStatus = c.String(nullable: false),
                        PresentPosition = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        JobGrade = c.Int(nullable: false),
                        Allowances = c.Double(nullable: false),
                        BasicSalary = c.Double(nullable: false),
                        VLCredits = c.Double(nullable: false),
                        SLCredits = c.Double(nullable: false),
                        Section = c.String(nullable: false),
                        AreaOfAssignment = c.String(nullable: false),
                        Department = c.String(nullable: false),
                        Division = c.String(nullable: false),
                        EmploymentStatus = c.String(nullable: false),
                        DateOfRegularization = c.DateTime(nullable: false),
                        TemporaryId = c.String(nullable: false),
                        PermanentId = c.String(nullable: false),
                        PermanentAddress = c.String(nullable: false),
                        SSSNo = c.String(),
                        PhilHealthNo = c.String(),
                        HDMFNo = c.String(),
                        PagibigNo = c.String(),
                        TINNo = c.String(),
                        ContactNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BetaLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false),
                        MName = c.String(nullable: false),
                        LName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateApplied = c.DateTime(nullable: false),
                        AreaOfDesignation = c.String(nullable: false),
                        SourceOfApplication = c.String(nullable: false),
                        PositionApplied = c.String(nullable: false),
                        BusinessUnit = c.String(nullable: false),
                        WorkExp = c.String(nullable: false),
                        EducationalBg = c.String(nullable: false),
                        School = c.String(nullable: false),
                        Remarks = c.String(nullable: false),
                        InitialStatus = c.String(),
                        HRScreening = c.String(),
                        Examination = c.String(),
                        DeptAssessment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConfirmPassword = c.String(),
                        Username = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Roles = c.String(nullable: false),
                        IsEmailVerified = c.Boolean(nullable: false),
                        ActivationCode = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.BetaLists");
            DropTable("dbo.AlphaLists");
        }
    }
}
