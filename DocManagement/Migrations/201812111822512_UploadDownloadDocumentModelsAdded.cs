namespace DocManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UploadDownloadDocumentModelsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Tags = c.String(nullable: false),
                        UploadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Downloads",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DownloadDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        DocumentId = c.Int(nullable: false),
                        AplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Documents", t => t.DocumentId, cascadeDelete: true)
                .Index(t => t.DocumentId)
                .Index(t => t.AplicationUserId);
            
            CreateTable(
                "dbo.Uploads",
                c => new
                    {
                        DocumentId = c.Int(nullable: false),
                        UploadDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        AplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.AspNetUsers", t => t.AplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Documents", t => t.DocumentId)
                .Index(t => t.DocumentId)
                .Index(t => t.AplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Downloads", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Uploads", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Uploads", "AplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Downloads", "AplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Uploads", new[] { "AplicationUserId" });
            DropIndex("dbo.Uploads", new[] { "DocumentId" });
            DropIndex("dbo.Downloads", new[] { "AplicationUserId" });
            DropIndex("dbo.Downloads", new[] { "DocumentId" });
            DropTable("dbo.Uploads");
            DropTable("dbo.Downloads");
            DropTable("dbo.Documents");
        }
    }
}
