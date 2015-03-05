using System.Data.Entity;

namespace EL.EntityModels.Contexts
{
	public class GeneralContext : BaseContext<GeneralContext>
	{
		public DbSet<DomainModels.BaseCategory> Categories { get; set; }
	}
}
