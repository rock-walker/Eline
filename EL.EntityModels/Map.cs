using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace EL.EntityModels
{
	public class MapContext: DbContext
	{
		public MapContext() : base("LineConnection"){}
		public DbSet<Marker> Map { get; set; }
	}

	[Table("Markers")]
	public class Marker
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public virtual int Id { get; set; }
		public virtual double? Lat { get; set; }
		public virtual double? Lng { get; set; }
		public virtual int CategoryId { get; set; }
		public Category Category { get; set; }
	} 
}
