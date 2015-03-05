using System.Data.Entity;
using EL.EntityModels.Models;

namespace EL.EntityModels.Contexts
{
	public class EntrepreneursContext : BaseContext<EntrepreneursContext>
	{
		public DbSet<Entrepreneurs> Entrepreneurs { get; set; }
		public DbSet<Stuff> Stuff { get; set; }
		public DbSet<DomainModels.BaseCategory> Categories { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<GeoMarker> GeoMarkers { get; set; }
		public DbSet<CalendarDay> CalendarDays { get; set; }
	}
}
