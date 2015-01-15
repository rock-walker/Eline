using System.Data.Entity;

namespace EL.EntityModels.Contexts
{
	public class GeneralContext : BaseContext<GeneralContext, _GeneralMigrations.Configuration>
	{
		public DbSet<DomainModels.BaseCategory> Categories { get; set; }
	}
}
