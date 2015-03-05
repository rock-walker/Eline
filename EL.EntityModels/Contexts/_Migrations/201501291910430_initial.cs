namespace EL.EntityModels.Contexts._Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Avatars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CalendarDay",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UtcDate = c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"),
                        Category_Id = c.Int(),
                        Entrepreneurs_Id = c.Int(),
                        Movable_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Entrepreneurs", t => t.Entrepreneurs_Id)
                .ForeignKey("dbo.Movables", t => t.Movable_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Entrepreneurs_Id)
                .Index(t => t.Movable_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Parent = c.Int(nullable: false),
                        Title = c.String(),
                        Link = c.String(),
                        Entrepreneurs_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entrepreneurs", t => t.Entrepreneurs_Id)
                .Index(t => t.Entrepreneurs_Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Start = c.Long(nullable: false),
                        End = c.Long(nullable: false),
                        CalendarDay_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CalendarDay", t => t.CalendarDay_Id)
                .Index(t => t.CalendarDay_Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mobile = c.String(),
                        Municipal = c.String(),
                        Email = c.String(),
                        Chat = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Experience = c.String(),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id)
                .Index(t => t.Contact_Id);
            
            CreateTable(
                "dbo.Entrepreneurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Details_Id = c.Int(),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Details", t => t.Details_Id)
                .ForeignKey("dbo.Markers", t => t.Location_Id)
                .Index(t => t.Details_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Markers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lat = c.Double(),
                        Lng = c.Double(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Stuff",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShortDescription = c.String(),
                        First = c.String(maxLength: 40),
                        Last = c.String(maxLength: 40),
                        Middle = c.String(maxLength: 40),
                        Ava_Id = c.Int(),
                        Category_Id = c.Int(),
                        Entrepreneurs_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Avatars", t => t.Ava_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Entrepreneurs", t => t.Entrepreneurs_Id)
                .Index(t => t.Ava_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Entrepreneurs_Id);
            
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
                        Ava_Id = c.Int(),
                        Category_Id = c.Int(),
                        Details_Id = c.Int(),
                        Gallery_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Avatars", t => t.Ava_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Details", t => t.Details_Id)
                .ForeignKey("dbo.Gallery", t => t.Gallery_Id)
                .Index(t => t.Ava_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Details_Id)
                .Index(t => t.Gallery_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movables", "Gallery_Id", "dbo.Gallery");
            DropForeignKey("dbo.Movables", "Details_Id", "dbo.Details");
            DropForeignKey("dbo.Movables", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.CalendarDay", "Movable_Id", "dbo.Movables");
            DropForeignKey("dbo.Movables", "Ava_Id", "dbo.Avatars");
            DropForeignKey("dbo.Stuff", "Entrepreneurs_Id", "dbo.Entrepreneurs");
            DropForeignKey("dbo.Stuff", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Stuff", "Ava_Id", "dbo.Avatars");
            DropForeignKey("dbo.Entrepreneurs", "Location_Id", "dbo.Markers");
            DropForeignKey("dbo.Markers", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Entrepreneurs", "Details_Id", "dbo.Details");
            DropForeignKey("dbo.Categories", "Entrepreneurs_Id", "dbo.Entrepreneurs");
            DropForeignKey("dbo.CalendarDay", "Entrepreneurs_Id", "dbo.Entrepreneurs");
            DropForeignKey("dbo.Details", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.Reservations", "CalendarDay_Id", "dbo.CalendarDay");
            DropForeignKey("dbo.CalendarDay", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Movables", new[] { "Gallery_Id" });
            DropIndex("dbo.Movables", new[] { "Details_Id" });
            DropIndex("dbo.Movables", new[] { "Category_Id" });
            DropIndex("dbo.CalendarDay", new[] { "Movable_Id" });
            DropIndex("dbo.Movables", new[] { "Ava_Id" });
            DropIndex("dbo.Stuff", new[] { "Entrepreneurs_Id" });
            DropIndex("dbo.Stuff", new[] { "Category_Id" });
            DropIndex("dbo.Stuff", new[] { "Ava_Id" });
            DropIndex("dbo.Entrepreneurs", new[] { "Location_Id" });
            DropIndex("dbo.Markers", new[] { "Category_Id" });
            DropIndex("dbo.Entrepreneurs", new[] { "Details_Id" });
            DropIndex("dbo.Categories", new[] { "Entrepreneurs_Id" });
            DropIndex("dbo.CalendarDay", new[] { "Entrepreneurs_Id" });
            DropIndex("dbo.Details", new[] { "Contact_Id" });
            DropIndex("dbo.Reservations", new[] { "CalendarDay_Id" });
            DropIndex("dbo.CalendarDay", new[] { "Category_Id" });
            DropTable("dbo.Movables");
            DropTable("dbo.Gallery");
            DropTable("dbo.Stuff");
            DropTable("dbo.Markers");
            DropTable("dbo.Entrepreneurs");
            DropTable("dbo.Details");
            DropTable("dbo.Contacts");
            DropTable("dbo.Reservations");
            DropTable("dbo.Categories");
            DropTable("dbo.CalendarDay");
            DropTable("dbo.Avatars");
        }
    }
}
