using System.ComponentModel.DataAnnotations.Schema;

namespace EL.EntityModels.Models
{
	[Table("Movables")]
	public class Movable : DomainModels.Specialist
	{
		public virtual Details Details { get; set; }
		public virtual Gallery Gallery { get; set; }
	}
	/*
	[Table("CategoriesToMovables")]
	public class CategoriesToMovables
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public virtual int Id { get; set; }
		public virtual Category Category { get; set; }
		public virtual Movable Movable { get; set; }
	}
	 * */
}
