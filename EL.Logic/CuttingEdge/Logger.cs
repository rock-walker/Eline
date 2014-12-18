using System;
using EL.Logic.Diagnostics;

namespace EL.Logic.CuttingEdge
{
	//IContext was removed
	//TODO: ISubject from Rx should be exchanged to IObserver or to events
	public class Logger : ILogger
	{
		//readonly ISubject<LogEntry> _subject;
		readonly IObserver<LogEntry> _subject;
		readonly LogEventType _level;
		readonly string _name;

		public Logger(/*LogEventType level, string name = null, IObserver<LogEntry> subject = null, ISubject<LogEntry> subject = null*/)
		{
			_level = LogEventType.Verbose;//level;
			_subject = /*subject ??*/ new LoggerObserver<LogEntry>();//new Subject<LogEntry>();
			_name = /*name*/"sss333" ?? string.Empty;
		}

		public bool ShouldTrace(LogEventType eventType)
		{
			return (_level & LogEventType.LevelMask) >= (eventType & LogEventType.LevelMask);
		}

		public void Write(LogEventType eventType, int id)
		{
			if (ShouldTrace(eventType))
				_subject.OnNext(new LogEntry(eventType, _name, id, null));
		}

		public void Write(LogEventType eventType, int id, string message)
		{
			if (ShouldTrace(eventType))
				_subject.OnNext(new LogEntry(eventType, _name, id, message));
		}

		public void Write(LogEventType eventType, int id, string format, params object[] args)
		{
			if (ShouldTrace(eventType))
				_subject.OnNext(new LogEntry(eventType, _name, id, format, args));
		}

		public void WriteData(LogEventType eventType, int id, object data)
		{
			if (ShouldTrace(eventType))
				_subject.OnNext(new LogEntry(eventType, _name, id, null, data));
		}

		public void WriteData(LogEventType eventType, int id, params object[] data)
		{
			if (ShouldTrace(eventType))
				_subject.OnNext(new LogEntry(eventType, _name, id, null, data));
		}
		
		public IDisposable Subscribe(IObserver<LogEntry> observer)
		{
			//TODO: temporarily commented. Need to find correct usage
			throw new NotImplementedException();
			//return _subject.Subscribe(observer);
		}
		
	}
}
