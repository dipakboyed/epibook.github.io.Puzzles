using System;
using System.Collections.Generic;

namespace EPI.Sorting
{
	/// <summary>
	/// Write a function which takes a sorted array of disjoint closed intervals and an interval to be added and
	/// returns the union of the disjoint intervals sorted by the left endpoint
	/// </summary>
	/// <example>
	/// {(-4,-1),(0,2),(3,6),(7,9),(11,12),(14,17)} and (1,8) returns {(-4,-1),(0,9),(11,12),(14,17)}
	/// </example>
	public static class DisjointIntervals
	{
		public struct Interval
		{
			public int left;
			public int right;
		};

		public static List<Interval> UnionInterval(List<Interval> disjointIntervals, Interval newInterval)
		{
			// Since the input disjointInterval is sorted, we could find the union interval via binary search O(logn)
			// but since the return value requires scanning the entire disjointInterval anyways O(n), we can just
			// find the union interval while iterating and not have to do binary search

			int i = 0;
			List<Interval> result = new List<Interval>();

			//1. First add all intervals that end before the new interval starts
			while (i < disjointIntervals.Count && disjointIntervals[i].right < newInterval.left)
			{
				result.Add(disjointIntervals[i++]);
			}

			// 2. Now find overlapping interval
			while (i < disjointIntervals.Count && disjointIntervals[i].left <= newInterval.right)
			{
				newInterval = new Interval()
				{
					left = Math.Min(newInterval.left, disjointIntervals[i].left),
					right = Math.Max(newInterval.right, disjointIntervals[i].right)
				};
				i++;
			}
			result.Add(newInterval);

			// 3. lastly, add all remaining intervals that start after the new interval ends
			while (i < disjointIntervals.Count)
			{
				result.Add(disjointIntervals[i++]);
			}

			return result;
		}
	}
}
