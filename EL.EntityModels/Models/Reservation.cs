using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EL.EntityModels.Models
{
	[Table("Reservations")]
	public class Reservation
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		public short StartH { get; set; }
		public short StartM { get; set; }
		public short EndH { get; set; }
		public short EndM { get; set; }
		public short Status { get; set; }
	}
}
