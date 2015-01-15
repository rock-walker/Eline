using System.Data.Entity;
using EL.EntityModels.Contexts._MovablesMigrations;
using EL.EntityModels.Models;

namespace EL.EntityModels.Contexts
{
	public class MovablesContext : BaseContext<MovablesContext>
	{
		public DbSet<Movable> Movables { get; set; }
		public DbSet<Gallery> Gallery { get; set; }
		public DbSet<DomainModels.BaseCategory> Categories { get; set; }
		public DbSet<Details> Details { get; set; }
		public DbSet<Contact> Contacts { get; set; }
	}
}
