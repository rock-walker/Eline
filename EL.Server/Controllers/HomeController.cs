using System.Web.Mvc;
using EL.Server.Base;

namespace EL.Server.Controllers
{
	public class HomeController : GenericController
	{
		//
		// GET: /Home/

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult Contact()
		{
			return View();
		}
	}
}
