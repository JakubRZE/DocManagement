namespace DocManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPositionDelete : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Position");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Position", c => c.String(nullable: false));
        }
    }
}
