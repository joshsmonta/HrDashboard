namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixPositionTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Positions", "Department_DeptId", "dbo.Departments");
            DropForeignKey("dbo.Positions", "Division_DivId", "dbo.Divisions");
            DropForeignKey("dbo.Positions", "Section_SectId", "dbo.Sections");
            DropIndex("dbo.Positions", new[] { "Department_DeptId" });
            DropIndex("dbo.Positions", new[] { "Division_DivId" });
            DropIndex("dbo.Positions", new[] { "Section_SectId" });
            RenameColumn(table: "dbo.Positions", name: "Department_DeptId", newName: "DeptId");
            RenameColumn(table: "dbo.Positions", name: "Division_DivId", newName: "DivId");
            RenameColumn(table: "dbo.Positions", name: "Section_SectId", newName: "SectId");
            AlterColumn("dbo.Positions", "DeptId", c => c.Int(nullable: true));
            AlterColumn("dbo.Positions", "DivId", c => c.Int(nullable: true));
            AlterColumn("dbo.Positions", "SectId", c => c.Int(nullable: true));
            CreateIndex("dbo.Positions", "DivId");
            CreateIndex("dbo.Positions", "DeptId");
            CreateIndex("dbo.Positions", "SectId");
            AddForeignKey("dbo.Positions", "DeptId", "dbo.Departments", "DeptId", cascadeDelete: false);
            AddForeignKey("dbo.Positions", "DivId", "dbo.Divisions", "DivId", cascadeDelete: false);
            AddForeignKey("dbo.Positions", "SectId", "dbo.Sections", "SectId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Positions", "SectId", "dbo.Sections");
            DropForeignKey("dbo.Positions", "DivId", "dbo.Divisions");
            DropForeignKey("dbo.Positions", "DeptId", "dbo.Departments");
            DropIndex("dbo.Positions", new[] { "SectId" });
            DropIndex("dbo.Positions", new[] { "DeptId" });
            DropIndex("dbo.Positions", new[] { "DivId" });
            AlterColumn("dbo.Positions", "SectId", c => c.Int());
            AlterColumn("dbo.Positions", "DivId", c => c.Int());
            AlterColumn("dbo.Positions", "DeptId", c => c.Int());
            RenameColumn(table: "dbo.Positions", name: "SectId", newName: "Section_SectId");
            RenameColumn(table: "dbo.Positions", name: "DivId", newName: "Division_DivId");
            RenameColumn(table: "dbo.Positions", name: "DeptId", newName: "Department_DeptId");
            CreateIndex("dbo.Positions", "Section_SectId");
            CreateIndex("dbo.Positions", "Division_DivId");
            CreateIndex("dbo.Positions", "Department_DeptId");
            AddForeignKey("dbo.Positions", "Section_SectId", "dbo.Sections", "SectId");
            AddForeignKey("dbo.Positions", "Division_DivId", "dbo.Divisions", "DivId");
            AddForeignKey("dbo.Positions", "Department_DeptId", "dbo.Departments", "DeptId");
        }
    }
}
