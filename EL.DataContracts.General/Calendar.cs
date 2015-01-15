using System;
using System.Collections.Generic;

namespace EL.DataContracts.General
{
	public class Scheduler
	{
		public IEnumerable<DateTime> DefaultDayOffs;
		public IEnumerable<DateTime> CustomDayOffs;
	}

	public class DaySettings
	{
		public TimeSpan StartWorkTime;
		public TimeSpan EndWorkTime;
		public int DefaultInterruption;
	}

	public class CalendarDay
	{
		public IEnumerable<ReservationItem> WorkingRanges;
		public IEnumerable<ReservationItem> CustomInterruptions;
		public IEnumerable<Specialist> AvailableSpecialists;
	}

	public class ReservationItem
	{
		public int PersonCount;
		public int DefaultRange;
		public int CustomRange;
		public TimeRangeStatus Status;
		public TimeRangeType Type;
	}

	public enum TimeRangeStatus
	{
		Free,
		Reserved,
		Tentative
	}

	public enum TimeRangeType
	{
		Working,
		Interruption
	}
}
