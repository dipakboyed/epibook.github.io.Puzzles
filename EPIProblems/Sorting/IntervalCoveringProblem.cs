using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI.Sorting
{
	/// <summary>
	/// You are given a set of closed intervals. Design an efficient algorithm to find the 
	/// minimum number of numbers that covers all the intervals
	/// </summary>
	/// <example>
	/// Intervals: {[0,3],[2,6],[3,4],[6,9]} can be covered by visiting at 0,2,3,6 or 3,6 or 3,9 etc...
	/// The smallest number of times visit is required is 2. So 3,6 or 3,9 are valid answers
	/// </example>
	public static class IntervalCoveringProblem
	{
		public struct Interval
		{
			public int start;
			public int end;
		}

		private class EntryType : IComparable
		{
			public Interval interval;
			public bool isEndInterval;

			public int CompareTo(object obj)
			{
				EntryType entryType = obj as EntryType;
				if (entryType != null)
				{
					int myValue = isEndInterval ? interval.end : interval.start;
					int theirValue = (entryType.isEndInterval) ? entryType.interval.end : entryType.interval.start;
					return (myValue != theirValue) ?
						myValue.CompareTo(theirValue) : // first sort entry's with lowest value
							isEndInterval.CompareTo(entryType.isEndInterval);  // then sort by entry type (start is sorted before end) 
				}
				throw new InvalidOperationException();
			}
		}

		public static List<int> FindMinimumIntervalCoveringSet(Interval[] intervals)
		{
			EntryType[] entries = new EntryType[intervals.Length * 2];
			for (int i = 0; i < intervals.Length; i++)
			{
				entries[2 * i]	   = new EntryType() { interval = intervals[i], isEndInterval = false };
				entries[2 * i + 1] = new EntryType() { interval = intervals[i], isEndInterval = true };
			}
			QuickSort<EntryType>.Sort(entries); // sort the time entries giving preference to start over end

			List<int> result = new List<int>();
			HashSet<Interval> visitingEntries = new HashSet<Interval>(); // intervals that are currently being visited/processed
			HashSet<Interval> visited = new HashSet<Interval>(); // intervals that already been visited/processed
			// iterate all entries
			foreach (EntryType entry in entries)
			{
				if (!entry.isEndInterval)
				{
					// start entry, mark as visiting
					visitingEntries.Add(entry.interval);
				}
				else // end of an entry
				{
					if (!visited.Contains(entry.interval)) // end of an entry that we haven't finished visiting
					{
						result.Add(entry.interval.end); // add value to result
														//mark as visiting entries as visited
						foreach (var e in visitingEntries)
						{
							visited.Add(e);
							if (visited.Count == intervals.Length) //all entries visited, we are done
							{
								break;
							}
						}
						visitingEntries.Clear();
					}
				}
			}
			return result;
		}
	}
}
