namespace EL.EntityModels.Contexts._Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reservations1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Status", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "Status");
        }
    }
}
