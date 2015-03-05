using System;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using EL.Logic.Controller;
using Microsoft.Practices.Unity;

namespace EL.Logic.ApplicationLevel
{
	public class UnityHttpControllerActivator : IHttpControllerActivator
	{
		private readonly IUnityContainer _container;

		public UnityHttpControllerActivator(IUnityContainer container)
		{
			_container = container;
		}
	
		public IHttpController Create(System.Net.Http.HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
		{
			/*
			if (controllerDescriptor.ControllerName == "Calendar")
				_container.Resolve<IElineService>("entrepreneurs");
			*/
			return (IHttpController) _container.Resolve(controllerType);
		}
	} 
}
