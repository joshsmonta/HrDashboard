namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialStart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlphaLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfHire = c.DateTime(nullable: false),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Sex = c.String(nullable: false),
                        CivilStatus = c.String(nullable: false),
                        PresentPosition = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        JobGrade = c.Int(nullable: false),
                        Allowances = c.Double(nullable: false),
                        BasicSalary = c.Double(nullable: false),
                        VLCredits = c.Double(nullable: false),
                        SLCredits = c.Double(nullable: false),
                        AreaOfAssignment = c.String(nullable: false),
                        EmploymentStatus = c.String(nullable: false),
                        DateOfRegularization = c.DateTime(),
                        TemporaryId = c.String(nullable: false),
                        PermanentId = c.String(nullable: false),
                        PermanentAddress = c.String(nullable: false),
                        SSSNo = c.String(),
                        PhilHealthNo = c.String(),
                        HDMFNo = c.String(),
                        PagibigNo = c.String(),
                        TINNo = c.String(),
                        ContactNumber = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        FileName = c.String(),
                        PosId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.PosId)
                .Index(t => t.PosId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PosId = c.Int(nullable: false, identity: true),
                        PosType = c.String(),
                        PosName = c.String(),
                        PosStatus = c.String(),
                        InDivision = c.String(),
                        InDept = c.String(),
                        InSection = c.String(),
                        DivId = c.Int(nullable: false),
                        DeptId = c.Int(nullable: false),
                        SectId = c.Int(nullable: false),
                        Head = c.Boolean(nullable: false),
                        BusinessUnit = c.String(),
                        unitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PosId)
                .ForeignKey("dbo.BusinessUnits", t => t.unitId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DeptId, cascadeDelete: true)
                .ForeignKey("dbo.Divisions", t => t.DivId, cascadeDelete: true)
                .ForeignKey("dbo.Sections", t => t.SectId, cascadeDelete: true)
                .Index(t => t.DivId)
                .Index(t => t.DeptId)
                .Index(t => t.SectId)
                .Index(t => t.unitId);
            
            CreateTable(
                "dbo.BusinessUnits",
                c => new
                    {
                        unitId = c.Int(nullable: false, identity: true),
                        unitName = c.String(),
                    })
                .PrimaryKey(t => t.unitId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DeptId = c.Int(nullable: false, identity: true),
                        DeptName = c.String(),
                        DivId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeptId)
                .ForeignKey("dbo.Divisions", t => t.DivId, cascadeDelete: false)
                .Index(t => t.DivId);
            
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        DivId = c.Int(nullable: false, identity: true),
                        DivName = c.String(),
                    })
                .PrimaryKey(t => t.DivId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectId = c.Int(nullable: false, identity: true),
                        SectName = c.String(),
                        DeptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SectId)
                .ForeignKey("dbo.Departments", t => t.DeptId, cascadeDelete: false)
                .Index(t => t.DeptId);
            
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
                        InitStatRemarks = c.String(),
                        HrRemarks = c.String(),
                        ExamRemarks = c.String(),
                        DeptRemarks = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logbooks",
                c => new
                    {
                        LogId = c.Int(nullable: false, identity: true),
                        LogDate = c.DateTime(nullable: false),
                        LogType = c.String(),
                        Id = c.Int(),
                    })
                .PrimaryKey(t => t.LogId);
            
            CreateTable(
                "dbo.Plantillas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DivId = c.Int(nullable: false),
                        DeptId = c.Int(nullable: false),
                        SectId = c.Int(nullable: false),
                        AlphaList_Id = c.Int(nullable: false),
                        Position_PosId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AlphaLists", t => t.AlphaList_Id, cascadeDelete: true)
                .ForeignKey("dbo.Positions", t => t.Position_PosId, cascadeDelete: true)
                .Index(t => t.AlphaList_Id)
                .Index(t => t.Position_PosId);
            
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
            DropForeignKey("dbo.Plantillas", "Position_PosId", "dbo.Positions");
            DropForeignKey("dbo.Plantillas", "AlphaList_Id", "dbo.AlphaLists");
            DropForeignKey("dbo.AlphaLists", "PosId", "dbo.Positions");
            DropForeignKey("dbo.Positions", "SectId", "dbo.Sections");
            DropForeignKey("dbo.Sections", "DeptId", "dbo.Departments");
            DropForeignKey("dbo.Positions", "DivId", "dbo.Divisions");
            DropForeignKey("dbo.Positions", "DeptId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "DivId", "dbo.Divisions");
            DropForeignKey("dbo.Positions", "unitId", "dbo.BusinessUnits");
            DropIndex("dbo.Plantillas", new[] { "Position_PosId" });
            DropIndex("dbo.Plantillas", new[] { "AlphaList_Id" });
            DropIndex("dbo.Sections", new[] { "DeptId" });
            DropIndex("dbo.Departments", new[] { "DivId" });
            DropIndex("dbo.Positions", new[] { "unitId" });
            DropIndex("dbo.Positions", new[] { "SectId" });
            DropIndex("dbo.Positions", new[] { "DeptId" });
            DropIndex("dbo.Positions", new[] { "DivId" });
            DropIndex("dbo.AlphaLists", new[] { "PosId" });
            DropTable("dbo.Users");
            DropTable("dbo.Plantillas");
            DropTable("dbo.Logbooks");
            DropTable("dbo.BetaLists");
            DropTable("dbo.Sections");
            DropTable("dbo.Divisions");
            DropTable("dbo.Departments");
            DropTable("dbo.BusinessUnits");
            DropTable("dbo.Positions");
            DropTable("dbo.AlphaLists");
        }
    }
}
