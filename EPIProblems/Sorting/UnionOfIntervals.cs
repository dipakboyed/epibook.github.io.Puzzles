using System;
using System.Collections.Generic;

namespace EPI.Sorting
{
    /// <summary>
    /// Design an algorithm that takes as input a set of intervals and outputs their union expressed as a set of disjoint intervals.
    /// </summary>
    /// <example>
    /// {} => open interval, [] => closed interval
    /// {0,3},[1,1],[3,4},[2,4],[5,7},[7,8},[8,11},{9,11], [12,14],{12,16],{13,15},{16,17} returns
    /// {0,4],[5,11],[12,17}
    /// </example>
    public static class UnionOfIntervals
	{
		public struct Entry
		{
			public int value;
			public bool isOpenInterval;
		}

		public struct Interval
		{
			public Entry left;
			public Entry right;
		}

		private class EntryType : IComparable
		{
			public Entry entry;
			public bool isRightInterval;

			public int CompareTo(object obj)
			{
				EntryType entryType = obj as EntryType;
				if (entryType != null)
				{
					return (entry.value != entryType.entry.value) ?
						entry.value.CompareTo(entryType.entry.value) : // first sort entry's with lowest value
						(isRightInterval != entryType.isRightInterval) ?  
							isRightInterval.CompareTo(entryType.isRightInterval) :  // then sort by entry type which are left 
							(isRightInterval) ? (!entry.isOpenInterval).CompareTo(!entryType.entry.isOpenInterval)  : entry.isOpenInterval.CompareTo(entryType.entry.isOpenInterval); //then sort by closed interval entry 
				}
				throw new InvalidOperationException();
			}
		}

		public static List<Interval> FindUnionOfIntervals(List<Interval> intervals)
		{
			List<Interval> result = new List<Interval>();
			EntryType[] entries = new EntryType[intervals.Count * 2];
			for (int i = 0; i < intervals.Count; i++)
			{
				entries[2 * i] = new EntryType() { entry = intervals[i].left, isRightInterval = false };
				entries[2*i + 1] = new EntryType() { entry = intervals[i].right, isRightInterval = true };
			}

			QuickSort<EntryType>.Sort(entries);
			Stack<EntryType> stackedEntries = new Stack<EntryType>();
			foreach (EntryType entryType in entries)
			{
				if (!entryType.isRightInterval)
				{
					stackedEntries.Push(entryType);
				}
				else
				{
					EntryType oldestEntryInSet = stackedEntries.Pop();
					if (stackedEntries.Count == 0) // set is complete
					{
						result.Add(new Interval()
						{
							left = oldestEntryInSet.entry,
							right = entryType.entry
						});
					}
				}
			}
			return result;
		}
	}
}
