using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EL.EntityModels.Models
{
	[Table("Markers")]
	public class GeoMarker
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public double? Lat { get; set; }
		public double? Lng { get; set; }
		public virtual Category Category { get; set; }
	} 
}
