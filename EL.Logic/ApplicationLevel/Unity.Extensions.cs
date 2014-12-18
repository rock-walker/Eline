using Microsoft.Practices.Unity;
using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.WebPages;

namespace EL.Logic.ApplicationLevel
{
	/// <summary>
	/// Extensions for Microsoft Unity
	/// </summary>
	public static partial class UnityExtensions
	{
		public static IUnityContainer RegisterControllers<TModule, TController>(this IUnityContainer ioc, string module, params string[] namespaces)
		{
			var mt = typeof(TModule);
			var mns = namespaces.Concat(new[] { mt.Namespace + ".Controllers" }).ToLookup(x => x, StringComparer.InvariantCultureIgnoreCase);

			var controllers = from t in mt.Assembly.GetTypes()
							  where mns.Contains(t.Namespace) && typeof(TController).IsAssignableFrom(t) && !t.IsAbstract && !t.IsNotPublic
							  select t;

			Func<Type, string> getControllerName = t => t.Name.ToLowerInvariant();

			foreach (var t in controllers)
			{
				// register IController for controller's factory
				ioc.RegisterType(typeof (TController), t, module + "." + getControllerName(t), new HierarchicalLifetimeManager());

				// register subcontrollers if present
				t.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic)
					.Where(st => typeof(TController).IsAssignableFrom(st) && !st.IsAbstract && !st.IsNotPublic)
					.Select(st => ioc.RegisterType(typeof(TController), st, module + "." + getControllerName(t) + "." + getControllerName(st), new HierarchicalLifetimeManager()))
					.Count()
				;
			}

			return ioc;
		}

		public static IUnityContainer RegisterViews<T>(this IUnityContainer ioc, string module)
		{
			var mappings =
			(
				from type in typeof(T).Assembly.GetTypes()
				where typeof(WebPageRenderingBase).IsAssignableFrom(type)
				let pageVirtualPath = type.GetCustomAttributes(inherit: false).OfType<PageVirtualPathAttribute>().FirstOrDefault()
				where pageVirtualPath != null
				select new
				{
					path = VirtualPathUtility.Combine("~/" + module + "/", pageVirtualPath.VirtualPath.Substring(2)).ToLowerInvariant(),
					type = type
				}
			);

			foreach (var i in mappings)
				ioc.RegisterType(typeof(WebPageRenderingBase), i.type, i.path);

			return ioc;
		}
	}
}
