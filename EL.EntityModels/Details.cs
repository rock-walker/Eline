using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace EL.EntityModels
{
	public class DetailsContext : DbContext
	{
		public DetailsContext() : base("LineConnection"){}
		public DbSet<Details> Details { get; set; }
	}

	[Table("Details")]
	public class Details
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public virtual int Id { get; set; }
		public virtual Contacts Contact { get; set; }
		public virtual string Experience { get; set; }
	}
}
