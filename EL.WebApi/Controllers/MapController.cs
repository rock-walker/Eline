using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EL.EntityModels;

namespace EL.WebApi.Controllers
{
    public class MapController : ApiController
    {
		readonly MapContext _ctxMap = new MapContext();

	    public ICollection<Marker> Get()
	    {
		    return null;
	    }

	    public ICollection<Marker> Get(int id)
	    {
			var markers = _ctxMap.Map
				.Where(x => x.CategoryId == id
							|| x.Category.Parent == id) 
				.ToList();

			return markers;
	    }
    }
}
