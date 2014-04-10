using System;
using System.Security.Principal;
using System.Threading;

namespace IM.Logic
{
	public static class SessionPrincipal
	{
		public static IDisposable Apply(this IPrincipal principal)
		{
			var op = Thread.CurrentPrincipal;

			Thread.CurrentPrincipal = principal;

			return null;
			/*
			return System.Reactive.Disposables.Disposable.Create
				(
					() =>
					{
						Thread.CurrentPrincipal = op;
					}
				);
			*/
		}
	}
}