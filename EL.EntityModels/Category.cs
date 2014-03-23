using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace EL.EntityModels
{
	public class CategoryContext : DbContext
	{
		public CategoryContext() : base("LineConnection")
		{
		}

		public DbSet<Category> Categories { get; set; }
	}

	public class BaseCategory
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public virtual int Id { get; set; }
		public virtual int Parent { get; set; }
		public virtual IEnumerable<BaseCategory> SubCategories { get; set; } 
	}

	[Table("Category")]
	public class Category : BaseCategory
	{
		public virtual string Title { get; set; }
		public virtual string Link { get; set; }
	}
}