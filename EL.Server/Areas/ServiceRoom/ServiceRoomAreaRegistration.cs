using System.Web.Mvc;

namespace EL.Server.Areas.ServiceRoom
{
	public class ServiceRoomAreaRegistration : AreaRegistration
	{
		public override string AreaName
		{
			get
			{
				return "ServiceRoom";
			}
		}

		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute(
				"ServiceRoom_default",
				"ServiceRoom/{controller}/{action}/{id}",
				new { action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
