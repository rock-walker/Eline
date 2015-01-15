using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EL.DataContracts.General;

namespace EL.Logic.Controller
{
	public interface IReserve
	{
		Task<IEnumerable<ReservationItem>> GetDayReservations(DateTime dt);
		Task<DaySettings> GetDaySettings();
	}
}
