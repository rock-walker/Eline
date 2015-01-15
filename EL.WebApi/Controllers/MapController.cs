using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EL.EntityModels.Contexts;
using EL.EntityModels.Models;

namespace EL.WebApi.Controllers
{
    public class MapController : ApiController
    {
		readonly EntrepreneursContext _ctxMap = new EntrepreneursContext();

	    public ICollection<GeoMarker> Get()
	    {
		    return null;
	    }

	    public ICollection<GeoMarker> Get(int id)
	    {
			var markers = _ctxMap.GeoMarkers
				.Where(x => x.Category.Id == id
							|| x.Category.Parent == id)
				.ToList();

			return markers;
	    }
    }
}
