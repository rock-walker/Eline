namespace EL.EntityModels.Contexts._GeneralMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _23 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Parent = c.Int(nullable: false),
                        Title = c.String(),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            //DropTable("dbo.Category");
        }
        
        public override void Down()
        {/*
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Link = c.String(),
                        Parent = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            */
            DropTable("dbo.Categories");
        }
    }
}
