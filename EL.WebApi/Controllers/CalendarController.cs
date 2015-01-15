using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EL.DataContracts.General;
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

	    public async Task<IEnumerable<ReservationItem>> GetTodayReservations()
	    {
		    return await _calendar.GetDayReservations(DateTime.Today);
	    }
    }
}
