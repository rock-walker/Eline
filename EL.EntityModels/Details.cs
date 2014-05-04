using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace EL.EntityModels
{
	public class DetailsContext : DbContext
	{
		public DetailsContext() : base("LineConnection"){}
		public DbSet<Details> Details { get; set; }
		public DbSet<Contacts> Contacts { get; set; }
	}

	[Table("Details")]
	public class Details
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public virtual int Id { get; set; }
		public virtual int ContactId { get; set; }
		public Contacts Contact { get; set; }
		public virtual string Experience { get; set; }
	}

	[Table("Contacts")]
	public class Contacts
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public virtual int Id { get; set; }
		public virtual string Mobile { get; set; } //divided by ';'
		public virtual string Municipal { get; set; } //divided by ';'
		public virtual string Email { get; set; }
		public virtual string Chant { get; set; }
	}
}
