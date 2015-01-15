using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL.DataContracts.General;

namespace EL.Logic.Controller
{
	public class Calendar : IReserve
	{
		public Task<IEnumerable<ReservationItem>> GetDayReservations(DateTime dt)
		{
			throw new NotImplementedException();
		}

		public Task<DaySettings> GetDaySettings()
		{
			throw new NotImplementedException();
		}
	}
}
