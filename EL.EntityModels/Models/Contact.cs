using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EL.EntityModels.Models
{
	[Table("Contacts")]
	public class Contact
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Mobile { get; set; } //divided by ';'
		public string Municipal { get; set; } //divided by ';'
		public string Email { get; set; }
		public string Chat { get; set; }
	}
}
