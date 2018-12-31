namespace DocManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViewsPropDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Documents", "Views");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Documents", "Views", c => c.Int(nullable: false));
        }
    }
}
