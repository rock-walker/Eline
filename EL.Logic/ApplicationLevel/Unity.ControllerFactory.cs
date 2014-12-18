using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Microsoft.Practices.Unity;

namespace EL.Logic.ApplicationLevel
{
	public class UnityControllerFactory : IControllerFactory
	{
		readonly ISet<string> _apiNames;
		//readonly IContext _ctx;
		private IUnityContainer _ioc;

		public UnityControllerFactory(IUnityContainer ioc, IEnumerable<string> apiNames)
		{
			_ioc = ioc;
			//_ctx = ctx;
			_apiNames = apiNames.Aggregate(new HashSet<string>(), (s, v) => { s.Add(v); return s; });
		}

		public IController CreateController(RequestContext requestContext, string controllerName)
		{
			/*
			var controllerType = Type.GetType(string.Concat("api", ".", controllerName, "Controller"));
			var controller = Activator.CreateInstance<IController>(controllerType); //, new[] { logger }) as Controller;
			return controller;
			*/
			
			object module;

			if (requestContext.RouteData.Values.TryGetValue("module", out module))
				controllerName = module + "." + controllerName.ToLowerInvariant();
			else
				controllerName = controllerName.ToLowerInvariant();

			if (!_apiNames.Contains(controllerName))
				return null;

			var cType = Type.GetType(controllerName);
			if (cType == null)
				return null;

			return Activator.CreateInstance(cType) as IController;
			/*
			return Activator.CreateInstance<IController>(controllerName); //_ctx.Services.GetInstance<IController>(controllerName);
			*/
		}

		public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
		{
			return SessionStateBehavior.Default;
		}

		public void ReleaseController(IController controller)
		{
			var disposable = controller as IDisposable;
			if (disposable != null)
				disposable.Dispose();
		}
	}
}
