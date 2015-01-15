namespace EL.EntityModels.Contexts._MovablesMigrations
{
    using System.Data.Entity.Migrations;

	public sealed class Configuration : DbMigrationsConfiguration<MovablesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
	        AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"Contexts\_MovablesMigrations";
        }

        protected override void Seed(MovablesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
