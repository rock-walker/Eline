﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EL.EntityModels.Models
{
	[Table("Entrepreneurs")]
	public class Entrepreneurs
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Category> Categories { get; set; }
		public virtual GeoMarker Location { get; set; }
		public virtual Details Details { get; set; }
		public virtual ICollection<Stuff> Specialists { get; set; }
		public virtual ICollection<CalendarDay> CalendarDays { get; set; }
	}

	[Table("Stuff")]
	public class Stuff : DomainModels.Specialist
	{
		public virtual string ShortDescription { get; set; }
	}
}
