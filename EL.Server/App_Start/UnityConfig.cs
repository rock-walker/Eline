using System;
using System.Configuration;
using System.Runtime.Caching;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EL.Logic.ApplicationLevel;
using EL.Logic.Controller;
using EL.Logic.Core.Principal;
using EL.Logic.CuttingEdge;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace EL.Server
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// <param name="container">The unity container to configure.</param>
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
			//RegisterWebApiResolver(container);
			PreConfig(container);
			ConfigureFromFile(container);
	        CrossConcern(container);
	        WebApiConfig(container);

			container.ResolveAll<IBootstrapper>().ForEach(x => x.Run());

			PosConfig(container);
        }

		private static void PreConfig(IUnityContainer ioc)
		{
			ioc.RegisterType<ObjectCache, MemoryCache>
			(
				new ContainerControlledLifetimeManager(),
				new InjectionConstructor("El", new InjectionParameter<System.Collections.Specialized.NameValueCollection>(null))
			);

			ioc.RegisterInstance(GlobalFilters.Filters);
			ioc.RegisterInstance(RouteTable.Routes);
		}

		private static void ConfigureFromFile(IUnityContainer ioc)
		{
			var config = ConfigurationManager.OpenMappedExeConfiguration
			(
				new ExeConfigurationFileMap
				{
					ExeConfigFilename = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "Unity.config")
				}
				, ConfigurationUserLevel.None
			);

			var section = (UnityConfigurationSection)config.GetSection("unity");

			if (section != null)
				ioc.LoadConfiguration(section);
		}

	    private static void CrossConcern(IUnityContainer ioc)
	    {
		    ioc.RegisterType<ILogger, Logger>(new HierarchicalLifetimeManager());
	    }

	    private static void WebApiConfig(IUnityContainer ioc)
	    {
		    ioc.RegisterType<IMovable, MovableItem>(new HierarchicalLifetimeManager());
	    }

		private static void PosConfig(IUnityContainer ioc)
		{
			ioc.RegisterType<ISessionPrincipal>
				(
					new InjectionFactory(
						c => Thread.CurrentPrincipal as ISessionPrincipal
						)
				);
		}
    }
}
