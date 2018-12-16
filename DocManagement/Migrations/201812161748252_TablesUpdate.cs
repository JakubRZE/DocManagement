namespace DocManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablesUpdate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Documents", name: "AplicationUserId", newName: "ApplicationUserId");
            RenameColumn(table: "dbo.Downloads", name: "AplicationUserId", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.Documents", name: "IX_AplicationUserId", newName: "IX_ApplicationUserId");
            RenameIndex(table: "dbo.Downloads", name: "IX_AplicationUserId", newName: "IX_ApplicationUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Downloads", name: "IX_ApplicationUserId", newName: "IX_AplicationUserId");
            RenameIndex(table: "dbo.Documents", name: "IX_ApplicationUserId", newName: "IX_AplicationUserId");
            RenameColumn(table: "dbo.Downloads", name: "ApplicationUserId", newName: "AplicationUserId");
            RenameColumn(table: "dbo.Documents", name: "ApplicationUserId", newName: "AplicationUserId");
        }
    }
}
