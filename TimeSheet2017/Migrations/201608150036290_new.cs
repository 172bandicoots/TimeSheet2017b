namespace TimeSheet2017.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TimeLogs", "JobNote", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TimeLogs", "JobNote", c => c.String(nullable: false));
        }
    }
}
