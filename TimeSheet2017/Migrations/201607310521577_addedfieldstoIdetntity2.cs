namespace TimeSheet2017.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfieldstoIdetntity2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AssociateName", c => c.String());
            DropColumn("dbo.AspNetUsers", "CompanyName");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "Zipcode");
            DropColumn("dbo.AspNetUsers", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Zipcode", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "State", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "City", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "CompanyName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.AspNetUsers", "AssociateName");
        }
    }
}
