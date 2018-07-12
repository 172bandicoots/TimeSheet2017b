namespace TimeSheet2017.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        ContactName = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 25),
                        State = c.String(nullable: false),
                        Zipcode = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClientID);
            
            CreateTable(
                "dbo.TimeLogs",
                c => new
                    {
                        LogID = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false),
                        AssociateName = c.String(nullable: false),
                        ClientID = c.Int(nullable: false),
                        WorkDate = c.DateTime(nullable: false),
                        NumberHours = c.Single(nullable: false),
                        WorkType = c.String(nullable: false),
                        JobNote = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LogID)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .Index(t => t.ClientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeLogs", "ClientID", "dbo.Clients");
            DropIndex("dbo.TimeLogs", new[] { "ClientID" });
            DropTable("dbo.TimeLogs");
            DropTable("dbo.Clients");
        }
    }
}
