﻿using System;
using System.Collections.Generic;

namespace EPI.Sorting
{
	/// <summary>
	/// Write a program that takes a set of calendar events (with start and end times) and determines
	/// the maximum number of calendar events taking place concurrently
	/// </summary>
	public static class RenderCalendar
	{
		public struct CalendarEvent
		{
			public DateTime Start;
			public DateTime Finish;

			public CalendarEvent(DateTime start, DateTime finish)
			{
				Start = start;
				Finish = finish;
			}
		};

		private class Entry : IComparable
		{
			private DateTime _time;
			public readonly bool IsEventStart;

			public Entry(DateTime time, bool isStart)
			{
				_time = time;
				IsEventStart = isStart;
			}

			public int CompareTo(object obj)
			{
				Entry e = obj as Entry;
				if (e != null)
				{
					return (_time != e._time) ? _time.CompareTo(e._time) : IsEventStart.CompareTo(e.IsEventStart);
				}
				throw new InvalidOperationException();
			}
		}

		public static int FindMaxConcurrentEvents(List<CalendarEvent> events)
		{
			// foreach calendar event add a time entry for its start and end time
			Entry[] entries = new Entry[events.Count * 2];
			for (int i = 0; i < events.Count; i++)
			{
				entries[2 * i]	 = new Entry(events[i].Start, true);
				entries[2 * i + 1] = new Entry(events[i].Finish, false);
			}

			// sort all time entries
			QuickSort<Entry>.Sort(entries);

			int maxConcurrentEntries = 0;
			int currentConcurrentEntriesCount = 0;
			foreach (Entry entry in entries)
			{
				if (entry.IsEventStart)
				{
					++currentConcurrentEntriesCount;
					if (maxConcurrentEntries < currentConcurrentEntriesCount)
					{
						maxConcurrentEntries = currentConcurrentEntriesCount;
					}
				}
				else
				{
					--currentConcurrentEntriesCount;
				}
			}
			return maxConcurrentEntries;
		}
	}
}
