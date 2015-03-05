using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EL.DataContracts.General;
using EL.EntityModels.Models;
using EL.Logic.Controller;

namespace EL.WebApi.Controllers
{
    public class CalendarController : ApiController
    {
	    private readonly IReserve _calendar;

	    public CalendarController(IReserve calendar)
	    {
		    _calendar = calendar;
	    }

	    public async Task<DaySettings> GetCalendarSettings()
	    {
		    return await _calendar.GetDaySettings();
	    }

		//[Route("serviceType/{srvType}/serviceId/{srvId:int}")]
	    public async Task<ICollection<Reservation>> GetTodayReservations(short srvType, int srvId)
	    {
		    return await _calendar.GetDayReservations(srvType, srvId, DateTime.Today);
	    }
    }
}
