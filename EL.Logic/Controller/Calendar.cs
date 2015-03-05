using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EL.DataContracts.General;
using EL.EntityModels.Models;

namespace EL.Logic.Controller
{
	public class ElCalendar : IReserve
	{
		//movable or entrepreneurs context should be
		private readonly IElineServiceFactory _providerFactory;

		public ElCalendar(IElineServiceFactory provider)
		{
			_providerFactory = provider;
		}

		public Task<ICollection<Reservation>> GetDayReservations(short serviceType, int serviceId, DateTime dt)
		{
			return _providerFactory.Create(serviceType).GetDayReservations(serviceId, dt);
		}

		public Task<DaySettings> GetDaySettings()
		{
			throw new NotImplementedException();
		}
	}
}
