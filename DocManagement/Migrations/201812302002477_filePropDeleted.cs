namespace DocManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filePropDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Documents", "File");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Documents", "File", c => c.String(nullable: false));
        }
    }
}
