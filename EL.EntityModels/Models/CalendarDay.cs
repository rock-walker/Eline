using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EL.EntityModels.Models
{
	[Table("CalendarDay")]
	public class CalendarDay
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public virtual Guid Id { get; set; }
		public virtual ICollection<Reservation> Reservations { get; set; }
		public virtual Category Category { get; set; }
	}
}
