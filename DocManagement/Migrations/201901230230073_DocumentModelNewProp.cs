namespace DocManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentModelNewProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Documents", "ContentType", c => c.String(nullable: false));
            DropColumn("dbo.Documents", "Views");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Documents", "Views", c => c.Int(nullable: false));
            DropColumn("dbo.Documents", "ContentType");
            DropColumn("dbo.Documents", "Name");
        }
    }
}
