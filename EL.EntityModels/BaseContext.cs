using System.Data.Entity;
using System.Data.Entity.Migrations;


namespace EL.EntityModels
{
	public class BaseContext<TContext, TMigration>: DbContext 
		where TContext : DbContext 
		where TMigration: DbMigrationsConfiguration<TContext>, new()
	{
		static BaseContext()
		{
			//Database.SetInitializer();
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<TContext, TMigration>());
		}

		protected BaseContext(): base("LineConnection"){}
	}

	public class BaseContext<T> : DbContext where T : DbContext
	{
		static BaseContext()
		{
			Database.SetInitializer<T>(null);
		}

		protected BaseContext() : base("LineConnection"){}
	}
}
