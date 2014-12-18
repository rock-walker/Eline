using System.Web.Optimization;
using EL.Server.Base;

namespace EL.Server
{
	public static class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			RegisterStyleBundles(bundles);

			RegisterAdminStyleBundles(bundles);
			RegisterJavascriptBundles(bundles);
		}

		private static void RegisterStyleBundles(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle("~/Content/bootstrap")
							.Include("~/Content/front/plugins/font-awesome/css/font-awesome.css")
							.Include("~/Content/front/plugins/bootstrap/css/bootstrap.css"));

			bundles.Add(new StyleBundle("~/cssBundle/metronic")
							.Include("~/Content/front/css/custom.css")
							.Include("~/Content/front/css/style-metronic.css")
							.Include("~/Content/front/css/style-responsive.css")
							.Include("~/Content/front/css/themes/red.css"));

			bundles.Add(new StyleBundle("~/cssBundle/frontHome")
							.Include("~/Content/front/plugins/fancybox/source/jquery.fancybox.css")
							.Include("~/Content/front/plugins/bxslider/jquery.bxslider.css"));
		}

		private static void RegisterJavascriptBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/jsBundle/base")
				.Include("~/Scripts/thirdParty/json2.js")
				.Include("~/Scripts/thirdParty/jquery-1.11.0.js")
				.Include("~/Scripts/thirdParty/jquery-migrate-1.2.1.js")
				//.Include("~/Scripts/thirdParty/jquery.mixitup.min.js")
				//.Include("~/Scripts/thirdParty/underscore.js")
				//.Include("~/Scripts/thirdParty/backbone.js")

				//START: base manual scripts -> add here manually
				.Include("~/Scripts/base/el.js")
				.Include("~/Scripts/base/date.js")
				.Include("~/Scripts/base/elapp.js")
				.ForceOrdered());
				//END:
			bundles.Add(new ScriptBundle("~/jsBundle/Backbone")
				.Include("~/Scripts/thirdParty/underscore.js")
				.Include("~/Scripts/thirdParty/backbone.js")
				.Include("~/Scripts/base/Router.js")
				.IncludeDirectory("~/Scripts/views", "*.js", true)
				.IncludeDirectory("~/Scripts/resources", "*.js", true)
				.IncludeDirectory("~/Scripts/compositeViews", "*.js", true)
				.IncludeDirectory("~/Scripts/models", "*.js", true)
				.IncludeDirectory("~/Scripts/collections", "*.js", true)
				.ForceOrdered());

			bundles.Add(new ScriptBundle("~/jsBundle/front")
				.IncludeDirectory("~/Content/front/scripts", "*.js", true)
				.IncludeDirectory("~/Content/front/plugins/animated-header", "*.js", true)
				.IncludeDirectory("~/Content/front/plugins/bootstrap", "*.js", true)
				.IncludeDirectory("~/Content/front/plugins/bxslider", "*.js", true)
				.IncludeDirectory("~/Content/front/plugins/fancybox", "*.js", true)
				.IncludeDirectory("~/Content/front/plugins/flexslider", "*.js", true)
				.IncludeDirectory("~/Content/front/plugins/revolution_slider", "*.js", true)
				.IncludeDirectory("~/Content/front/plugins/uniform", "*.js", true)
				.IncludeDirectory("~/Content/front/plugins/gmaps", "*.js", true)
				.Include("~/Content/front/plugins/back-to-top.js")
				.Include("~/Content/front/plugins/hover-dropdown.js"));
		}

		private static void RegisterAdminStyleBundles(BundleCollection bundles)
		{
			//bundles.Add(new StyleBundle("/cssBundle/adminHome"));
		}
	}
}