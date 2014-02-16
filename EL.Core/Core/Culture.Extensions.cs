using System;
using System.Globalization;
using System.Threading;

namespace EL.Core
{
	public static class CultureExtensions
	{
		public static int SafeId(this CultureInfo culture)
		{
			return (culture ?? Thread.CurrentThread.CurrentUICulture).LCID;
		}
	}

	public static class CultureInfoHelper
	{
		public static CultureInfo GetCultureInfoSafe(string name)
		{
			try
			{
				return CultureInfo.GetCultureInfo(name);
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
