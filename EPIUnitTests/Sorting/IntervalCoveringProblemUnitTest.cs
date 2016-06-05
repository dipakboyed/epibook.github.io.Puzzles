using System.Collections.Generic;
using EPI.Sorting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Sorting
{
	[TestClass]
	public class IntervalCoveringProblemUnitTest
	{
		[TestMethod]
		public void FindMinimumCoveringSet()
		{
			IntervalCoveringProblem.Interval[] intervals = new IntervalCoveringProblem.Interval[]
			{
				new IntervalCoveringProblem.Interval() {start = 0, end = 3 },
				new IntervalCoveringProblem.Interval() {start = 2, end = 6 },
				new IntervalCoveringProblem.Interval() {start = 3, end = 4 },
				new IntervalCoveringProblem.Interval() {start = 6, end = 9 }
			};
			IntervalCoveringProblem.FindMinimumIntervalCoveringSet(intervals).ShouldBeEquivalentTo(new List<int>() { 3, 9 });
		}
	}
}
