using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
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
			return (IHttpController) _container.Resolve(controllerType);
		}
	} 
}
