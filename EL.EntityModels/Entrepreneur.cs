using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace EL.EntityModels
{
	public class EntrepreneursContext : DbContext
	{
		public EntrepreneursContext() : base("LineConnection"){}
		public DbSet<Entrepreneurs> Entrepreneurs { get; set; } 
	}

	[Table("Entrepreneurs")]
	public class Entrepreneurs
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual IEnumerable<Category> Categories { get; set; }
		public virtual Marker Location { get; set; }
		public virtual Details Details { get; set; }
	}
}
