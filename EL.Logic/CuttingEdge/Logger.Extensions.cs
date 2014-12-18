using System;
using System.Text;
using System.Linq;

namespace EL.Logic.CuttingEdge
{
	public static class LoggerEx
	{
		public static void Trace(this ILogger log, LogEventType type, string message)
		{
			if (log != null)
				log.Write(type, 0, message);
		}

		public static void Trace(this ILogger log, LogEventType type, string format, params object[] args)
		{
			if (log != null)
				log.Write(type, 0, format, args);
		}

		public static void Trace(this ILogger log, LogEventType type, Exception err, string message)
		{
			if (log != null && log.ShouldTrace(type))
				log.Trace(LogEventType.Error, 
					(new StringBuilder()).Append(message ?? "Exception").Append(" : ").FormatException(err).ToString());
		}

		public static void Trace(this ILogger log, LogEventType type, Exception err)
		{
			log.Trace(type, err, null);
		}

		public static StringBuilder FormatException(this StringBuilder sb, Exception err)
		{
			if (err != null && sb != null)
			{
				sb.FormatException(err, string.Empty);

				var i = err.InnerException;
				var j = 0;

				for (; i != null; i = i.InnerException)
					sb.AppendLine().FormatException(i, string.Format(System.Globalization.CultureInfo.InvariantCulture, "[{0}] : ", j++));
			}

			return sb;
		}

		public static StringBuilder FormatException(this StringBuilder sb, Exception err, string prefix)
		{
			if (err != null && sb != null)
			{
				sb.Append(prefix).Append(err.GetType());

				if (!string.IsNullOrEmpty(err.Message))
					sb.Append(" : ").Append(err.Message.Replace(Environment.NewLine, "\\n"));

				if (err.StackTrace != null)
				{
					err.StackTrace.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
						.Aggregate(sb, (a, s) => a.AppendLine().Append(prefix).Append(s));
				}
			}
			return sb;
		}

		public static void Error(this ILogger log, string message)
		{
			log.Trace(LogEventType.Error, message);
		}

		public static void Error(this ILogger log, string format, params object[] args)
		{
			log.Trace(LogEventType.Error, format, args);
		}

		public static void Warning(this ILogger log, string message)
		{
			log.Trace(LogEventType.Warning, message);
		}

		public static void Warning(this ILogger log, string format, params object[] args)
		{
			log.Trace(LogEventType.Warning, format, args);
		}

		public static void Info(this ILogger log, string message)
		{
			log.Trace(LogEventType.Information, message);
		}

		public static void Info(this ILogger log, string format, params object[] args)
		{
			log.Trace(LogEventType.Information, format, args);
		}

		public static void Verbose(this ILogger log, string message)
		{
			log.Trace(LogEventType.Verbose, message);
		}

		public static void Verbose(this ILogger log, string format, params object[] args)
		{
			log.Trace(LogEventType.Verbose, format, args);
		}

		public static void Error(this ILogger log, Exception err, string message)
		{
			log.Trace(LogEventType.Error, err, message);
		}

		public static void Error(this ILogger log, Exception err)
		{
			log.Trace(LogEventType.Error, err, null);
		}
	}
}
