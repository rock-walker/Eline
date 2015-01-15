using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EL.EntityModels.Models;

namespace EL.EntityModels
{
	[Table("Details")]
	public class Details
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public virtual Contact Contact { get; set; }
		public string Experience { get; set; }
	}
}
