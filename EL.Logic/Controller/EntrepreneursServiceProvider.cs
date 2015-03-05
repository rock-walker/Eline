using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EL.EntityModels.Contexts;
using EL.EntityModels.Models;
using Model = EL.DataContracts.General;

namespace EL.Logic.Controller
{
	public class EntrepreneursServiceProvider : IElineService
	{
		private EntrepreneursContext _db;

		public EntrepreneursServiceProvider(EntrepreneursContext db)
		{
			_db = db;
		}

		public Task<ICollection<Reservation>> GetDayReservations(int serviceId, DateTime date)
		{
			return Task.Run(() =>
			{
				var entrepreneur = _db.Entrepreneurs.SingleOrDefault(x => x.Id == serviceId);

				if (entrepreneur == null || !entrepreneur.CalendarDays.Any())
					return null;

				var bookingDay = entrepreneur.CalendarDays.FirstOrDefault(x => x.UtcDate.Date == date.Date);

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
