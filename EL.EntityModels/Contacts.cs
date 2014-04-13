using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace EL.EntityModels
{
	public class ContactsContext: DbContext
	{
		public ContactsContext() : base("LineConnection"){}
		public DbSet<Contacts> Contacts { get; set; }
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
