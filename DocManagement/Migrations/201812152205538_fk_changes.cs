namespace DocManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fk_changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Downloads", "AplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Downloads", "AplicationUserId");
            AddForeignKey("dbo.Downloads", "AplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Downloads", "AplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Downloads", new[] { "AplicationUserId" });
            DropColumn("dbo.Downloads", "AplicationUserId");
        }
    }
}
