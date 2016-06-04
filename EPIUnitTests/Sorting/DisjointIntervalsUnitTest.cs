using System.Collections.Generic;
using EPI.Sorting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Sorting
{
	[TestClass]
	public class DisjointIntervalsUnitTest
	{
		[TestMethod]
		public void UnionIntervals()
		{
			List<DisjointIntervals.Interval> set = new List<DisjointIntervals.Interval>()
			{
				new DisjointIntervals.Interval() {left = -4, right = -1 },
				new DisjointIntervals.Interval() {left = 0, right = 2 },
				new DisjointIntervals.Interval() {left = 3, right = 6 },
				new DisjointIntervals.Interval() {left = 7, right = 9 },
				new DisjointIntervals.Interval() {left = 11, right = 12 },
				new DisjointIntervals.Interval() {left = 14, right = 17 }
			};
			DisjointIntervals.UnionInterval(set, new DisjointIntervals.Interval() { left = 1, right = 8 }).
				ShouldBeEquivalentTo( new List<DisjointIntervals.Interval>()
				{
					new DisjointIntervals.Interval() {left = -4, right = -1 },
					new DisjointIntervals.Interval() {left = 0, right = 9 },
					new DisjointIntervals.Interval() {left = 11, right = 12 },
					new DisjointIntervals.Interval() {left = 14, right = 17 }
				});
		}
	}
}
