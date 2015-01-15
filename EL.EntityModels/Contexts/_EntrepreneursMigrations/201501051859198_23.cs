namespace EL.EntityModels.Contexts._EntrepreneursMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _23 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mobile = c.String(),
                        Municipal = c.String(),
                        Email = c.String(),
                        Chant = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.CalendarDay",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Category_Id = c.Int(),
                        Entrepreneurs_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Entrepreneurs", t => t.Entrepreneurs_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Entrepreneurs_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Link = c.String(),
                        Parent = c.Int(nullable: false),
                        Entrepreneurs_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entrepreneurs", t => t.Entrepreneurs_Id)
                .Index(t => t.Entrepreneurs_Id);
            
            CreateTable(
                "dbo.Reservation",
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
                        Ava_AvaId = c.Int(nullable: false),
                        Ava_Image = c.Binary(),
                        Category_Id = c.Int(),
                        Entrepreneurs_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Entrepreneurs", t => t.Entrepreneurs_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Entrepreneurs_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stuff", "Entrepreneurs_Id", "dbo.Entrepreneurs");
            DropForeignKey("dbo.Stuff", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Entrepreneurs", "Location_Id", "dbo.Markers");
            DropForeignKey("dbo.Markers", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Entrepreneurs", "Details_Id", "dbo.Details");
            DropForeignKey("dbo.Details", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.Categories", "Entrepreneurs_Id", "dbo.Entrepreneurs");
            DropForeignKey("dbo.CalendarDay", "Entrepreneurs_Id", "dbo.Entrepreneurs");
            DropForeignKey("dbo.Reservation", "CalendarDay_Id", "dbo.CalendarDay");
            DropForeignKey("dbo.CalendarDay", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Stuff", new[] { "Entrepreneurs_Id" });
            DropIndex("dbo.Stuff", new[] { "Category_Id" });
            DropIndex("dbo.Entrepreneurs", new[] { "Location_Id" });
            DropIndex("dbo.Markers", new[] { "Category_Id" });
            DropIndex("dbo.Entrepreneurs", new[] { "Details_Id" });
            DropIndex("dbo.Details", new[] { "Contact_Id" });
            DropIndex("dbo.Categories", new[] { "Entrepreneurs_Id" });
            DropIndex("dbo.CalendarDay", new[] { "Entrepreneurs_Id" });
            DropIndex("dbo.Reservation", new[] { "CalendarDay_Id" });
            DropIndex("dbo.CalendarDay", new[] { "Category_Id" });
            DropTable("dbo.Stuff");
            DropTable("dbo.Markers");
            DropTable("dbo.Details");
            DropTable("dbo.Reservation");
            DropTable("dbo.Categories");
            DropTable("dbo.CalendarDay");
            DropTable("dbo.Entrepreneurs");
            DropTable("dbo.Contacts");
        }
    }
}
