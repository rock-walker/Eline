using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using EL.DataContracts.General;
using EL.EntityModels.Models;

namespace EL.Logic.Controller
{
	//general behavior for movables and entrepreneurs serviceProviders
	public interface IElineService
	{
		Task<ICollection<Reservation>> GetDayReservations(int serviceId, DateTime date);
		Task<ICollection<Reservation>> GetWeekReservation(int serviceId, DateTime startWeekDay);
		Task<ICollection<Reservation>> GetMonthReservation(int serviceId, DateTime startMonthDay);
	}

	public interface IElineServiceFactory
	{
		IElineService Create(short serviceType);
	}
}
