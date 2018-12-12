namespace DocManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsReorganization : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Uploads", "AplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Uploads", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Downloads", "AplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Downloads", "DocumentId", "dbo.Documents");
            DropIndex("dbo.Uploads", new[] { "DocumentId" });
            DropIndex("dbo.Uploads", new[] { "AplicationUserId" });
            RenameColumn(table: "dbo.Downloads", name: "AplicationUserId", newName: "AplicationUser_Id");
            RenameIndex(table: "dbo.Downloads", name: "IX_AplicationUserId", newName: "IX_AplicationUser_Id");
            DropPrimaryKey("dbo.Documents");
            AddColumn("dbo.Documents", "UploadDate", c => c.DateTime(nullable: false, defaultValueSql: "GETDATE()"));
            AddColumn("dbo.Documents", "File", c => c.String(nullable: false));
            AddColumn("dbo.Documents", "AplicationUserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Documents", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Documents", "Id");
            CreateIndex("dbo.Documents", "AplicationUserId");
            AddForeignKey("dbo.Documents", "AplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Downloads", "AplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Downloads", "DocumentId", "dbo.Documents", "Id", cascadeDelete: true);
            DropColumn("dbo.Documents", "Name");
            DropColumn("dbo.Documents", "Tags");
            DropColumn("dbo.Documents", "UploadId");
            DropTable("dbo.Uploads");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Uploads",
                c => new
                    {
                        DocumentId = c.Int(nullable: false),
                        UploadDate = c.DateTime(nullable: false),
                        AplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.DocumentId);
            
            AddColumn("dbo.Documents", "UploadId", c => c.Int(nullable: false));
            AddColumn("dbo.Documents", "Tags", c => c.String(nullable: false));
            AddColumn("dbo.Documents", "Name", c => c.String(nullable: false));
            DropForeignKey("dbo.Downloads", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Downloads", "AplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Documents", "AplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Documents", new[] { "AplicationUserId" });
            DropPrimaryKey("dbo.Documents");
            AlterColumn("dbo.Documents", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Documents", "AplicationUserId");
            DropColumn("dbo.Documents", "File");
            DropColumn("dbo.Documents", "UploadDate");
            AddPrimaryKey("dbo.Documents", "Id");
            RenameIndex(table: "dbo.Downloads", name: "IX_AplicationUser_Id", newName: "IX_AplicationUserId");
            RenameColumn(table: "dbo.Downloads", name: "AplicationUser_Id", newName: "AplicationUserId");
            CreateIndex("dbo.Uploads", "AplicationUserId");
            CreateIndex("dbo.Uploads", "DocumentId");
            AddForeignKey("dbo.Downloads", "DocumentId", "dbo.Documents", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Downloads", "AplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Uploads", "DocumentId", "dbo.Documents", "Id");
            AddForeignKey("dbo.Uploads", "AplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
