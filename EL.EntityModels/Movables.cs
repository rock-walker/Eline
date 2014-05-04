using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace EL.EntityModels
{
	public class MovablesContext: DbContext
	{
		public MovablesContext() : base("LineConnection"){}
		public DbSet<Movables> Movables { get; set; }
		public DbSet<CategoriesToMovables> CategoriesToMovables { get; set; }
	}

	[Table("Movables")]
	public class Movables
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public virtual int Id { get; set; }
		public virtual string First { get; set; }
		public virtual string Last { get; set; }
		public virtual string Middle { get; set; }
		public virtual int? DetailsId { get; set; }
		public Details Details { get; set; }
		public virtual int? GalleryId { get; set; }
		public Gallery Gallery { get; set; }
	}

	[Table("CategoriesToMovables")]
	public class CategoriesToMovables
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public virtual int Id { get; set; }
		public virtual int CategoryId { get; set; }
		public virtual int MovableId { get; set; }
	}
}
