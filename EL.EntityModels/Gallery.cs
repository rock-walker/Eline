using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace EL.EntityModels
{
	public class GalleryContext : DbContext
	{
		public GalleryContext(): base("LineConnection"){}
		public DbSet<Gallery> Gallery { get; set; } 
	}

	[Table("Gallery")]
	public class Gallery
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public virtual int Id { get; set; }
		public virtual string Results { get; set; }
		public virtual string Thumb { get; set; }
		public virtual string Certificates { get; set; }
	}
}
