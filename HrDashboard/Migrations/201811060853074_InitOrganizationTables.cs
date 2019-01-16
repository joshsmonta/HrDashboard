namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitOrganizationTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DeptId = c.Int(nullable: false, identity: true),
                        DeptName = c.String(),
                        DivId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeptId)
                .ForeignKey("dbo.Divisions", t => t.DivId, cascadeDelete: true)
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
                "dbo.Positions",
                c => new
                    {
                        PosId = c.Int(nullable: false, identity: true),
                        PosName = c.String(),
                        PosStatus = c.String(),
                        InDivision = c.String(),
                        InDept = c.String(),
                        InSection = c.String(),
                        Department_DeptId = c.Int(),
                        Division_DivId = c.Int(),
                        Section_SectId = c.Int(),
                    })
                .PrimaryKey(t => t.PosId)
                .ForeignKey("dbo.Departments", t => t.Department_DeptId)
                .ForeignKey("dbo.Divisions", t => t.Division_DivId)
                .ForeignKey("dbo.Sections", t => t.Section_SectId)
                .Index(t => t.Department_DeptId)
                .Index(t => t.Division_DivId)
                .Index(t => t.Section_SectId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectId = c.Int(nullable: false, identity: true),
                        SectName = c.String(),
                        DeptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SectId)
                .ForeignKey("dbo.Departments", t => t.DeptId, cascadeDelete: true)
                .Index(t => t.DeptId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Positions", "Section_SectId", "dbo.Sections");
            DropForeignKey("dbo.Sections", "DeptId", "dbo.Departments");
            DropForeignKey("dbo.Positions", "Division_DivId", "dbo.Divisions");
            DropForeignKey("dbo.Positions", "Department_DeptId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "DivId", "dbo.Divisions");
            DropIndex("dbo.Sections", new[] { "DeptId" });
            DropIndex("dbo.Positions", new[] { "Section_SectId" });
            DropIndex("dbo.Positions", new[] { "Division_DivId" });
            DropIndex("dbo.Positions", new[] { "Department_DeptId" });
            DropIndex("dbo.Departments", new[] { "DivId" });
            DropTable("dbo.Sections");
            DropTable("dbo.Positions");
            DropTable("dbo.Divisions");
            DropTable("dbo.Departments");
        }
    }
}
