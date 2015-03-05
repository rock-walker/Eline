using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EL.DataContracts.General;
using EL.EntityModels.Models;

namespace EL.Logic.Controller
{
	public interface IReserve
	{
		Task<ICollection<Reservation>> GetDayReservations(short serviceType, int serviceId, DateTime dt);
		Task<DaySettings> GetDaySettings();
	}
}
