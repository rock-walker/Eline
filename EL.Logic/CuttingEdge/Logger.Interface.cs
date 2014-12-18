using System;
using EL.Logic.Diagnostics;

namespace EL.Logic.CuttingEdge
{
	[Flags]
	public enum LogEventType
	{
		None = 0,
		Critical = 1,
		Error = 2,
		Warning = 4,
		Information = 8,
		Verbose = 16,
		LevelMask = Critical | Error | Warning | Information | Verbose
	}

	public partial interface ILogger : IObservable<LogEntry>
	{
		bool ShouldTrace(LogEventType eventType);

		void Write(LogEventType eventType, int id);
		void Write(LogEventType eventType, int id, string message);
		void Write(LogEventType eventType, int id, string format, params object[] args);

		void WriteData(LogEventType eventType, int id, object data);
		void WriteData(LogEventType eventType, int id, params object[] data);
	}
}
