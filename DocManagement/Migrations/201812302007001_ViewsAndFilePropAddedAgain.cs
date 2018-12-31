namespace DocManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewsAndFilePropAddedAgain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "File", c => c.Binary(nullable: false));
            AddColumn("dbo.Documents", "Views", c => c.Int(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "Views");
            DropColumn("dbo.Documents", "File");
        }
    }
}
