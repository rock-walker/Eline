using System.Web.Mvc;

namespace EL.Server.Areas.CustomerRoom
{
	public class CustomerRoomAreaRegistration : AreaRegistration
	{
		public override string AreaName
		{
			get
			{
				return "CustomerRoom";
			}
		}

		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute(
				"CustomerRoom_default",
				"CustomerRoom/{controller}/{action}/{id}",
				new { action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
