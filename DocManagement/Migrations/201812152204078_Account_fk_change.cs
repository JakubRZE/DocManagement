namespace DocManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Account_fk_change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Downloads", "AplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Downloads", new[] { "AplicationUser_Id" });
            DropColumn("dbo.Downloads", "AplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Downloads", "AplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Downloads", "AplicationUser_Id");
            AddForeignKey("dbo.Downloads", "AplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
