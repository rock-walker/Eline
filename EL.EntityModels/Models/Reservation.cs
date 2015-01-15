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
		public long Start { get; set; }
		public long End { get; set; }
	}
}
