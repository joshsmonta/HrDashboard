namespace HrDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogBookTable : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logbooks");
        }
    }
}
