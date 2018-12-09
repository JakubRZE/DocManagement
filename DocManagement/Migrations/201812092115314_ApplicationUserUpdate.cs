namespace DocManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Position", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "RegistrationDate", c => c.DateTime(defaultValueSql: "GETDATE()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "RegistrationDate");
            DropColumn("dbo.AspNetUsers", "Position");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
