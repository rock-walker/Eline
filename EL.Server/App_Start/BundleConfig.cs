using System.Web.Optimization;
using EL.Server.Base;

namespace EL.Server
{
	public static class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			RegisterStyleBundles(bundles);
			RegisterJavascriptBundles(bundles);
		}

		private static void RegisterStyleBundles(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle("~/cssBundle/front")
							.IncludeDirectory("~/Content/front/css", "*.css", true)
							.IncludeDirectory("~/Content/front/plugins", "*.css", true)
							.IncludeDirectory("~/Content/front/fonts", "*.css", true));
		}

		private static void RegisterJavascriptBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/jsBundle/base")
				.Include("~/Scripts/thirdParty/jquery-1.11.0.js")
				.Include("~/Scripts/thirdParty/jquery-migrate-1.2.1.js")
				//.Include("~/Scripts/thirdParty/jquery.mixitup.min.js")
				.Include("~/Scripts/thirdParty/underscore.js")
				.Include("~/Scripts/thirdParty/backbone.js")
				//.Include("~/Scripts/main.js")
				.IncludeDirectory("~/Scripts/base", "*.js", true)
				.IncludeDirectory("~/Scripts/resources", "*.js", true)
				.IncludeDirectory("~/Scripts/models", "*.js", true)
				.IncludeDirectory("~/Scripts/controllers", "*.js", true)
				.IncludeDirectory("~/Scripts/views", "*.js", true).ForceOrdered());

			bundles.Add(new ScriptBundle("~/jsBundle/front")
				.IncludeDirectory("~/Content/front/plugins/animated-header", "*.js", true)
				.IncludeDirectory("~/Content/front/plugins/bootstrap", "*.js", true)
				.IncludeDirectory("~/Content/front/plugins/bxslider", "*.js", true)
				.IncludeDirectory("~/Content/front/plugins/fancybox", "*.js", true)
				.IncludeDirectory("~/Content/front/plugins/flexslider", "*.js", true)
				.IncludeDirectory("~/Content/front/plugins/revolution_slider", "*.js", true)
				.IncludeDirectory("~/Content/front/plugins/uniform", "*.js", true)
				.Include("~/Content/front/plugins/back-to-top.js")
				.Include("~/Content/front/plugins/hover-dropdown.js")
				.IncludeDirectory("~/Content/front/scripts", "*.js", true));
		}
	}
}