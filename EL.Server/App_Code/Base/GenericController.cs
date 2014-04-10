using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using EL.Logic.ApplicationLevel;
using EL.Logic.Core;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.Unity;

namespace EL.Server.Base
{
	/// <summary>
	/// This is the base controller for dealing with switching between EW and GHC views
	/// </summary>
	[ValidateInput(false)]
	public class GenericController : Controller
	{
		#region Properties
		/*
		[Dependency]
		public ILogger Log { get; set; }
		*/
		[Dependency]
		public ILocaleReader Locale { get; set; }
		/*
		[Dependency("appType")]
		public string AppType { get; set; }

		[Dependency]
		public ISessionPrincipal Principal { get; set; }
		*/

		#endregion

		#region Methods

		protected override void Initialize(RequestContext requestContext)
		{
			base.Initialize(requestContext);
			if (Locale != null)
			{
				ViewData["locale"] = Locale.GetLocale();
			}
			SetModuleSettings();
		}

		private void CopySettings(ViewDataDictionary vd, string prefix, ModuleSettingsElement settings)
		{
			if (settings != null && settings.Settings != null)
			{
				if (String.IsNullOrEmpty(prefix))
					prefix = "";
				foreach (var k in settings.Settings.AllKeys)
				{
					vd[prefix + k] = settings.Settings[k].Value;
				}
			}
		}

		[ChildActionOnly]
		protected ActionResult Error(HandleErrorInfo model)
		{
			Exception exc;
			var aex = model.Exception as AggregateException;
			if (aex != null)
			{
				exc = aex.Flatten().InnerException;
			}
			else
			{
				exc = model.Exception;
			}

			//if (Log != null) Log.Error(string.Format("[{0}]:[{1}]:[{2}]", model.ControllerName, model.ActionName, exc));
			return View("ErrorWithDetails", new HandleErrorInfo(exc, model.ControllerName, model.ActionName));
		}

		protected Task<ActionResult> HandleError(Func<Task<ActionResult>> action)
		{
			var controllerName = (string)RouteData.Values["controller"];
			var actionName = (string)RouteData.Values["action"];
			try
			{
				return
					action()
					.Catch(ex => Error(new HandleErrorInfo(ex, controllerName, actionName)))
				;
			}
			catch (Exception ex)
			{
				return Task.Factory.FromResult(Error(new HandleErrorInfo(ex, controllerName, actionName)));
			}
		}

		protected void SetModuleSettings()
		{
			using (IConfigurationSource source = new SystemConfigurationSource())
			{
				ModulesSettingsSection section = null;
				try
				{
					section = source.GetSection("module.definitions") as ModulesSettingsSection;
				}
				catch (Exception e)
				{
					/*if (Log != null)
						Log.Error(e);*/
				}
				if (section != null)
				{
					object module = "ew";
					/*
					if (section.DynamicContextSwitch == false || !ControllerContext.RouteData.Values.TryGetValue("module", out module))
					{
						module = AppType;
					}
					 * */
					if (module != null)
					{
						var moduleName = module.ToString();
						if (!string.IsNullOrWhiteSpace(moduleName) && section.Modules != null)
						{
							var settings = section.Modules.FirstOrDefault(x => x.Name == moduleName);
							if (settings != null && settings.Settings != null)
							{
								CopySettings(ViewData, "", settings);
								foreach (var p in settings.Pages)
								{
									CopySettings(ViewData, "pages." + p.Name + ".", p);
								}
							}
							ViewData["module"] = moduleName.ToLowerInvariant();
							HandleSettings(settings);
						}
					}
				}
			}
		}

		protected virtual void HandleSettings(PagesSettingsElement settings)
		{

		}

		#endregion
	}
}