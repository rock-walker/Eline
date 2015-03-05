using System.Data.Entity;
using EL.EntityModels.Models;

namespace EL.EntityModels.Contexts
{
	public class CalendarContext : BaseContext<CalendarContext>
	{
		public DbSet<Reservation> Reservations { get; set; }
		public DbSet<CalendarDay> CalendarDays { get; set; }
	}
}
