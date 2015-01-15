using System.Data.Entity;
using EL.EntityModels.Contexts._Migrations;
using EL.EntityModels.Models;

namespace EL.EntityModels.Contexts
{
	public class MigrationContext: BaseContext<MigrationContext, Configuration>
	{
		//Movables
		public DbSet<Movable> Movables { get; set; }
		public DbSet<Gallery> Gallery { get; set; }
		//**public DbSet<DomainModels.BaseCategory> Categories { get; set; }
		public DbSet<Details> Details { get; set; }
		public DbSet<Contact> Contacts { get; set; }

		//Calendar
		public DbSet<Reservation> Reservations { get; set; }
		public DbSet<CalendarDay> CalendarDays { get; set; }

		//Entrepreneurs
		public DbSet<Entrepreneurs> Entrepreneurs { get; set; }
		public DbSet<Stuff> Stuff { get; set; }
		//**public DbSet<DomainModels.BaseCategory> Categories { get; set; }
		//**public DbSet<Contact> Contacts { get; set; }
		public DbSet<GeoMarker> GeoMarkers { get; set; }

		//General
		public DbSet<DomainModels.BaseCategory> Categories { get; set; }

		public DbSet<DomainModels.AvatarImage> Avatars { get; set; }
	}
}
