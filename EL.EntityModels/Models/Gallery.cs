using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EL.EntityModels.Models
{
	[Table("Gallery")]
	public class Gallery
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Thumbnail { get; set; }
		public Guid FolderId { get; set; }
	}
}
