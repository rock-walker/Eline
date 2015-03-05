namespace EL.EntityModels.Contexts._Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reservations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "StartH", c => c.Short(nullable: false));
            AddColumn("dbo.Reservations", "StartM", c => c.Short(nullable: false));
            AddColumn("dbo.Reservations", "EndH", c => c.Short(nullable: false));
            AddColumn("dbo.Reservations", "EndM", c => c.Short(nullable: false));
            DropColumn("dbo.Reservations", "Start");
            DropColumn("dbo.Reservations", "End");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "End", c => c.Long(nullable: false));
            AddColumn("dbo.Reservations", "Start", c => c.Long(nullable: false));
            DropColumn("dbo.Reservations", "EndM");
            DropColumn("dbo.Reservations", "EndH");
            DropColumn("dbo.Reservations", "StartM");
            DropColumn("dbo.Reservations", "StartH");
        }
    }
}
