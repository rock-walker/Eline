namespace EL.EntityModels.Contexts._EntrepreneursMigrations
{
	using System.Data.Entity.Migrations;

	public sealed class Configuration : DbMigrationsConfiguration<EntrepreneursContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
	        AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"Contexts\_EntrepreneursMigrations";
        }

        protected override void Seed(EntrepreneursContext context)
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
