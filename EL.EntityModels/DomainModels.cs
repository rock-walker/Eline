using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EL.EntityModels.Models;

namespace EL.EntityModels
{
	public class DomainModels
	{
		public abstract class Specialist
		{
			[Key]
			[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
			public int Id { get; set; }
			[StringLength(40)]
			public string First { get; set; }
			[StringLength(40)]
			public string Last { get; set; }
			[StringLength(40)]
			public string Middle { get; set; }
			public virtual AvatarImage Ava { get; set; }
			public virtual Category Category { get; set; }
		}

		[Table("Avatars")]
		public class AvatarImage
		{
			[Key]
			[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
			public int Id { get; set; }
			public virtual byte[] Image { get; set; }
		}

		[Table("Categories")]
		public abstract class BaseCategory
		{
			[Key]
			[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
			public int Id { get; set; }
			public int Parent { get; set; }
		}
		
		public abstract class ChildrenCategory : BaseCategory
		{
			[NotMapped]
			public IEnumerable<BaseCategory> SubCategories { get; set; } //ICollection ?
		}
	}
}
