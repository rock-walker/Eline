using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using EL.Logic.ApplicationLevel;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(EL.Server.UnityWebActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(EL.Server.UnityWebActivator), "Shutdown")]

namespace EL.Server
{
    /// <summary>Provides the bootstrapping for integrating Unity with ASP.NET MVC.</summary>
    public static class UnityWebActivator
    {
        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start() 
        {
            var container = UnityConfig.GetConfiguredContainer();
	        container.RegisterInstance<IHttpControllerActivator>(new UnityHttpControllerActivator(container));

            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
	        GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
	        // TODO: Uncomment if you want to use PerRequestLifetimeManager
	        // Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }

        /// <summary>Disposes the Unity container when the application is shut down.</summary>
        public static void Shutdown()
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }
    }
}