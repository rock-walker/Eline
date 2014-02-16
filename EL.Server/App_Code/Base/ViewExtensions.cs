using System;
using System.Web.Configuration;
using System.Web.Mvc;

namespace EL.Server.Base
{
    public static class ViewExtensions
    {
        #region Methods

        public static bool IsGHC(this WebViewPage<dynamic> view)
        {
            return view.ViewData["module"] != null && view.ViewData["module"].ToString() == "ghc";
        }

		public static bool IsEnterprise(this WebViewPage<dynamic> view)
		{
			bool isEnterprise = false;

			if (Boolean.TryParse(WebConfigurationManager.AppSettings["Enterprise"], out isEnterprise))
				return IsGHC(view) && isEnterprise;
			
			return false;
		}

		public static string GetModule(this WebViewPage<dynamic> view)
		{
			return view.ViewData["module"] != null ? view.ViewData["module"].ToString() : string.Empty;
		}

		public static string GetModule<TModel>(this WebViewPage<TModel> view)
		{
			return view.ViewData["module"] != null ? view.ViewData["module"].ToString() : string.Empty;
		}

        #endregion
    }
}