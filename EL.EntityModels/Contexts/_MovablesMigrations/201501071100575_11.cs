namespace EL.EntityModels.Contexts._MovablesMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gallery",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Thumbnail = c.String(),
                        FolderId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        First = c.String(maxLength: 40),
                        Last = c.String(maxLength: 40),
                        Middle = c.String(maxLength: 40),
                        Ava_AvaId = c.Int(),
                        Category_Id = c.Int(),
                        Details_Id = c.Int(),
                        Gallery_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Avatar", t => t.Ava_AvaId)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Details", t => t.Details_Id)
                .ForeignKey("dbo.Gallery", t => t.Gallery_Id)
                .Index(t => t.Ava_AvaId)
                .Index(t => t.Category_Id)
                .Index(t => t.Details_Id)
                .Index(t => t.Gallery_Id);
           
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movables", "Gallery_Id", "dbo.Gallery");
            DropForeignKey("dbo.Movables", "Details_Id", "dbo.Details");
            DropForeignKey("dbo.Movables", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Movables", "Ava_AvaId", "dbo.Avatar");
            DropForeignKey("dbo.Details", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.Movables", new[] { "Gallery_Id" });
            DropIndex("dbo.Movables", new[] { "Details_Id" });
            DropIndex("dbo.Movables", new[] { "Category_Id" });
            DropIndex("dbo.Movables", new[] { "Ava_AvaId" });
            DropIndex("dbo.Details", new[] { "Contact_Id" });
            DropTable("dbo.Avatar");
            DropTable("dbo.Movables");
            DropTable("dbo.Gallery");
            DropTable("dbo.Details");
            DropTable("dbo.Contacts");
            DropTable("dbo.Categories");
        }
    }
}
