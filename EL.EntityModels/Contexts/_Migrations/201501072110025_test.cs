namespace EL.EntityModels.Contexts._Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Chat", c => c.String());
            DropColumn("dbo.Contacts", "Chant");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Chant", c => c.String());
            DropColumn("dbo.Contacts", "Chat");
        }
    }
}
