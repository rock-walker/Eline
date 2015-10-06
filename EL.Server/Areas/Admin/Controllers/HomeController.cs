using System.Web.Mvc;
using EL.Server.Base;
using EL.Server.Filters;

namespace EL.Server.Areas.Admin.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class HomeController : GenericController
    {
        //
        // GET: /Admin/Home/
        public ActionResult Index()
        {
            return View();
        }
	}
}