using System;
using System.Globalization;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Web;
using EL.Logic.Core.Principal;
using EL.Core;

namespace EL.Logic.Core
{
	public interface ILocaleReader
	{
		#region Methods

		/// <summary>
		/// Obtains current UI user culture from profile or request headers on first login
		/// </summary>
		/// <returns>Culture string identifier</returns>
		string GetLocale();

		/// <summary>
		/// Default culture specified in Unity.config
		/// </summary>
		string DefaultLocale { get; set; }

		#endregion
	}

	public sealed class LocaleReader : ILocaleReader
	{
		#region Constants

		private const string DefaultCulture = "en-US";
		private const string AcceptLanguageKey = "ACCEPTLANGUAGEKEY";

		#endregion
		#region Private

		private ISessionPrincipal _principal;
		//private ILogger _logger;

		#endregion
		#region Properties

		/// <summary>
		/// Flag for legacy clients which are not designed to accept culture changes on the fly
		/// </summary>
		public bool IgnoreClientLanguages { get; set; }

		/// <summary>
		/// Default culture specified in Unity.config
		/// </summary>
		public string DefaultLocale { get; set; }

		/// <summary>
		/// The list of supported UI cultures defined in Unity.config
		/// </summary>
		public string SupportedLanguages { get; set; }

		/// <summary>
		/// If true, the locale reader will try to cast the incoming culture identifier
		/// to the well known one: e.g. en-GB -> en-US. Well known means that GF products internally support 
		/// some languages available for translation - we're interested in them.
		/// </summary>
		public bool CastToWellKnownCulture { get; set; }

		#endregion
		#region Constructor

		public LocaleReader(ISessionPrincipal principal /*ILogger logger*/)
		{
			_principal = principal;
			//_logger = logger;
		}

		#endregion
		#region Methods

		/// <summary>
		/// Obtains current UI user culture from profile or request headers on first login
		/// </summary>
		/// <returns>Culture string identifier</returns>
		public string GetLocale()
		{
			// Return the culture of current thread if the user is not logged in or legacy client installation is used
			if (IgnoreClientLanguages || _principal == null) return Thread.CurrentThread.CurrentUICulture.Name;
			string locale;
			var lang = _principal.Language; // GFIN8 #35637 Language of Client UI selected in User Profile
			if (lang > 0) // If user has language defined in profile
			{
				try
				{
					// Use it
					locale = CultureInfo.GetCultureInfo(lang).Name;
				}
				catch (Exception e)
				{
					//_logger.Error(e);
					throw e;
				}
			}
			else
			{
				// Try parse request Accept-Languages header to select the language which matches with the available ones
				locale = ReadLocaleFromRequest();
			}
			if (string.IsNullOrEmpty(locale))
			{
				locale = DefaultLocale ?? string.Empty;
			}
			return locale;
		}

		private string ReadLocaleFromRequest()
		{
			var languages = CallContext.LogicalGetData(AcceptLanguageKey) as string[];
			if (languages != null)
			{
				foreach (var i in languages)
				{
					var locale = i;
					int index = i.IndexOf(';');
					if (index != -1)
					{
						locale = locale.Substring(0, index);
					}

					if (CastToWellKnownCulture)
					{
						var normalized = NormalizeLocaleWithCast(locale);
						if (!string.IsNullOrWhiteSpace(normalized))
							return normalized;
					}
					else if (IsMatchedWithAvailableLanguages(locale))
						return NormalizeLocale(locale);
				}
			}

			return null;
		}

		private string NormalizeLocale(string locale)
		{
			var lcid = Language.TwoLetterIsoLanguageName2Code(locale);
			if (lcid != 0)
				return CultureInfo.GetCultureInfo(lcid).Name;
			return locale;
		}

		/// <summary>
		/// The method tries to 'cast' provided culture identifier to a well-known one (en-US,...)
		/// If parsing or casting the culture fails, null is returned.
		/// </summary>
		private string NormalizeLocaleWithCast(string locale)
		{
			CultureInfo info;
			if ((info = CultureInfoHelper.GetCultureInfoSafe(locale)) != null)
			{
				// Do fallback to 'main' culture (e.g. 'en-GB -> en-US' by recognising the culture by two first letters ('en'))
				// Note that 'main' culture is a mere internal contract (1033 is not 'main' for the world, but we consider it in this way)
				// TG 81.36052
				var lcid = Language.TwoLetterIsoLanguageName2Code(info.TwoLetterISOLanguageName.ToLower());
				if (lcid != 0) // found supported code
					return CultureInfo.GetCultureInfo(lcid).Name;
			}

			return null;
		}

		private bool IsMatchedWithAvailableLanguages(string locale)
		{
			return SupportedLanguages.IndexOf(locale.Substring(0, 2), StringComparison.OrdinalIgnoreCase) > -1;
		}

		public static void ReadLocaleFromRequest(HttpRequest request)
		{
			if (request == null) return;
			if (request.UserLanguages != null)
			{
				CallContext.LogicalSetData(AcceptLanguageKey, request.UserLanguages);
			}
		}

		#endregion
	}

	public static class LocaleReaderExtensions
	{
		#region Methods

		public static CultureInfo GetCultureInfo(this ILocaleReader locale)
		{
			return CultureInfo.GetCultureInfo(locale.GetLocale());
		}

		public static int GetLocaleId(this ILocaleReader locale)
		{
			var culture = locale.GetCultureInfo();
			if (culture != null)
			{
				return culture.LCID;
			}
			return 0;
		}

		#endregion
	}
}