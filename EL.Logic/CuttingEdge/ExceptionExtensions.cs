using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EL.Logic.CuttingEdge
{
	public static class ExceptionExtensions
	{
		// try extract agregated exception if it has single exception inside
		// if more than one exception reside in aggregator - return aggregator itsels
		public static Exception TryUnwrap(this Exception ex)
		{
			var agg = ex as AggregateException;

			if(agg != null)
			{
				var flt = agg.Flatten();
				if(flt.InnerExceptions.Count == 1)
					return flt.InnerException;
			}

			return ex;
		}

		static void AddHiddenInnerExceptions(Exception ex, List<Exception> list)
		{
			while (true)
			{
				if (ex == null)
					return;

				var aex = ex as AggregateException;
				var rfex = ex as ReflectionTypeLoadException;

				if (aex != null)
				{
					if (aex.InnerExceptions.Count > 1)
						list.AddRange(aex.InnerExceptions);

					for (int i = 1; i < aex.InnerExceptions.Count; i++)
					{
						AddHiddenInnerExceptions(aex.InnerExceptions[i], list);
					}
				}

				if (rfex != null)
				{
					if (rfex.LoaderExceptions.Length > 0)
						list.AddRange(rfex.LoaderExceptions);

					for (int i = 0; i < rfex.LoaderExceptions.Length; i++)
					{
						AddHiddenInnerExceptions(rfex.LoaderExceptions[i], list);
					}
				}

				ex = ex.InnerException;
			}
		}

		// convert 'multi' exceptions to form which can be viualized by IIS yellow page of death
		// (this page not display all Aggregate.Exceptions, but only InnerException)
		public static Exception TryUpgradeForVisualize(Exception ex)
		{
			var hiddenEistExceptions = new List<Exception>();
			AddHiddenInnerExceptions(ex, hiddenEistExceptions);

			if (hiddenEistExceptions.Count == 0)
				return ex;

			var sb = new StringBuilder();

			sb.AppendLine();
			sb.AppendLine();
			sb.AppendLine();
			sb.AppendLine("====================== HIDDEN EXCEPTIONS =============================");

			foreach (var hex in hiddenEistExceptions)
			{
				sb.AppendLine(hex.GetType().FullName + ": " + hex.Message);
			}

			sb.AppendLine("========================== MORE DETAILED =============================");

			foreach (var hex in hiddenEistExceptions)
			{
				sb.AppendLine(hex.ToString());
				sb.AppendLine("++++++++++++++++++++++++++++++");
			}

			sb.AppendLine("====================== HIDDEN EXCEPTIONS END =========================");
			sb.AppendLine();
			sb.AppendLine();

			return new ApplicationException(sb.ToString(), ex);
		}
	}
}
