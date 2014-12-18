using System;
using System.Threading;
using EL.Logic.CuttingEdge;

namespace EL.Logic.Diagnostics
{
	/// <summary>
	/// Provides trace event data specific to a thread and a process. 
	/// </summary>
	public partial class LogEntry
	{
		static int _processId;

		DateTime _time = DateTime.MinValue;
		string _callStack;
		long _timeStamp = -1L;
		object[] _logicalStack;
		int _threadId = -1;
		
		readonly LogEventType _eventType;
		readonly string _source;
		readonly int _id;
		readonly string _format;
		readonly object[] _data;

		/// <summary>
		/// Initializes a new instance of the LoggerEntry class.
		/// </summary>
		/// <param name="context"></param>
		public LogEntry(LogEventType eventType, string source, int id, string format, params object[] data)
		{
			_eventType = eventType;
			_source = source;
			_id = id;
			_format = format;
			_data = data;
		}

		/// <summary>
		/// Gets the call stack for the current thread.
		/// </summary>
		/// <value>
		/// A string containing stack trace information. This value can be an empty string
		/// </value>
		public string Callstack 
		{
			get
			{
				FreezeCallstack();
				return _callStack;
			}
		}
		/// <summary>
		/// Gets the date and time at which the event trace occurred.
		/// </summary>
		/// <value>
		/// A System.DateTime structure whose value is a date and time expressed in Coordinated
		/// Universal Time (UTC).
		/// </value>
		public DateTime DateTime 
		{
			get
			{ 
				FreezeTime();
				return _time;
			}
		}
		/// <summary>
		/// Gets the correlation data, contained in a stack.
		/// </summary>
		/// <value>
		/// A object[] containing correlation data.
		/// </value>
		public object[] LogicalStack 
		{
			get
			{ 
				FreezeLogicalStack();
				return _logicalStack;
			}
		}
		/// <summary>
		/// Gets the unique identifier of the current process.
		/// </summary>
		/// <value>
		/// The system-generated unique identifier of the current process.
		/// </value>
		public int ProcessId 
		{
			get
			{
				FreezeProcessId();
				return _processId;
			}
		}
		/// <summary>
		/// Gets a unique identifier for the current managed thread.
		/// </summary>
		/// <value>
		/// A string that represents a unique integer identifier for this managed thread.
		/// </value>
		public int ThreadId 
		{
			get
			{
				FreezeThreadId();
				return _threadId;
			}
		}
		/// <summary>
		/// Gets the current number of ticks in the timer mechanism.
		/// </summary>
		/// <value>
		/// The tick counter value of the underlying timer mechanism.
		/// </value>
		public long Timestamp 
		{
			get
			{
				FreezeTimestamp();
				return _timeStamp;
			}
		}

		public LogEventType EventType
		{
			get { return _eventType; }
		}

		public string Source
		{
			get { return _source; }
		}

		public int Id
		{
			get { return _id; }
		}

		public string Format
		{
			get { return _format; }
		}

		public object[] Data
		{
			get { return _data; }
		}

		#region [ Freeze helpres ]

		partial void FreezeLogicalStack();

		void FreezeTime()
		{
			if (_time == DateTime.MinValue)
				_time = DateTime.UtcNow;
		}

		partial void FreezeTimestamp();

		partial void FreezeProcessId();

		void FreezeThreadId()
		{
			if (_threadId == -1)
				_threadId = Thread.CurrentThread.ManagedThreadId;
		}

		partial void FreezeCallstack();

		#endregion
	}
}
