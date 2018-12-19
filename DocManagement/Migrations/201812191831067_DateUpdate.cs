namespace DocManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documents", "UploadDate", c => c.DateTime(defaultValueSql: "GETDATE()"));
            AlterColumn("dbo.AspNetUsers", "RegistrationDate", c => c.DateTime(defaultValueSql: "GETDATE()"));
            AlterColumn("dbo.Downloads", "DownloadDate", c => c.DateTime(defaultValueSql: "GETDATE()"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Downloads", "DownloadDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "RegistrationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Documents", "UploadDate", c => c.DateTime(nullable: false));
        }
    }
}
