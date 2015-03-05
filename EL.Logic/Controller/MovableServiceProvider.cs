using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EL.EntityModels.Contexts;
using EL.EntityModels.Models;

namespace EL.Logic.Controller
{
	public class MovableServiceProvider : IElineService
	{
		private MovablesContext _db;

		public MovableServiceProvider(MovablesContext db)
		{
			_db = db;
		}

		public Task<ICollection<Reservation>> GetDayReservations(int serviceId, DateTime date)
		{
			return Task.Run(() =>
			{
				var movable = _db.Movables.SingleOrDefault(x => x.Id == serviceId);

				if (movable == null || !movable.CalendarDays.Any())
					return null;

				var bookingDay = movable.CalendarDays.FirstOrDefault(x => x.UtcDate.Date == date.Date);

				return (bookingDay != null && bookingDay.Reservations.Any())
					? bookingDay.Reservations
					: null;
			});
		}


		public Task<ICollection<Reservation>> GetWeekReservation(int serviceId, DateTime startWeekDay)
		{
			throw new NotImplementedException();
		}

		public Task<ICollection<Reservation>> GetMonthReservation(int serviceId, DateTime startMonthDay)
		{
			throw new NotImplementedException();
		}
	}
}
