using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Routing;
using EL.Logic.ApplicationLevel;
using EL.Logic.WebApiCore;
using Microsoft.Practices.Unity;

namespace EL.WebApi
{
	public class Bootstrapper : IBootstrapper
	{
		private readonly IUnityContainer _ioc;
		private readonly RouteCollection _routes;
		//private readonly HttpConfiguration _configuration;

		public Bootstrapper(IUnityContainer ioc, RouteCollection routes/*, HttpConfiguration configuration*/)
		{
			_ioc = ioc;
			_routes = routes;
			//_configuration = configuration;
		}

		private void SetupRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			/*
			routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional, action="get" }
			);
			*/

			routes.MapHttpRoute(
				"MapRoute",
				"api/map/{id}",
				new { module="api", controller = "map", id = RouteParameter.Optional }	
			);
			
			routes.MapHttpRoute(
				name: "DefaultApiWithAction",
				routeTemplate: "api/category/{action}/{id}",
				defaults: new { controller = "category", id = RouteParameter.Optional, action="get" }
			);

			routes.MapHttpRoute(
				"Movables",
				"api/movable/{action}/{id}",
				new { module="api", controller = "movable", id = RouteParameter.Optional, action="get"}
			);
		}
		
		private void Initialize()
		{
			SetupRoutes(_routes);

			var configuration = GlobalConfiguration.Configuration;
			configuration.Filters.Add(_ioc.Resolve<ApiExceptionHandlerFilter>());
			
			_ioc.RegisterControllers<Bootstrapper, IHttpController>("api");

			/*
			var elineControllerFactory = new UnityControllerFactory(_ioc, _ioc.Registrations
				.Where(x => x.RegisteredType == typeof (IHttpController))
				.Select(x => x.Name));

			_ioc.RegisterInstance<IControllerFactory>(elineControllerFactory);
			*/
			//_ioc.RegisterType(typeof(IMovable), typeof(Movable), "api.Movable", new HierarchicalLifetimeManager());
		}

		private static void RegisterElineCotrollerFactory(IUnityContainer ioc)
		{
			IControllerFactory factory = new UnityControllerFactory(ioc, ioc.Registrations
				.Where(x => x.RegisteredType == typeof(IHttpController))
				.Select(x => x.Name));
			//ControllerBuilder.Current.SetControllerFactory(factory);
		}

		public IDisposable Run()
		{
			Initialize();
			return null;
		}
	}
}