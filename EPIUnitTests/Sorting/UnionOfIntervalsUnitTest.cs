using System.Collections.Generic;
using EPI.Sorting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Sorting
{
	[TestClass]
	public class UnionOfIntervalsUnitTest
	{
		[TestMethod]
		public void FindUnionOfDisjointIntervals()
		{
			List<UnionOfIntervals.Interval> intervals = new List<UnionOfIntervals.Interval>()
			{
				new UnionOfIntervals.Interval() {left = new UnionOfIntervals.Entry() {value = 0, isOpenInterval = true}, right = new UnionOfIntervals.Entry() {value = 3, isOpenInterval = true }},
				new UnionOfIntervals.Interval() {left = new UnionOfIntervals.Entry() {value = 1, isOpenInterval = false}, right = new UnionOfIntervals.Entry() {value = 1, isOpenInterval = false }},
				new UnionOfIntervals.Interval() {left = new UnionOfIntervals.Entry() {value = 3, isOpenInterval = false}, right = new UnionOfIntervals.Entry() {value = 4, isOpenInterval = false }},
				new UnionOfIntervals.Interval() {left = new UnionOfIntervals.Entry() {value = 2, isOpenInterval = false}, right = new UnionOfIntervals.Entry() {value = 4, isOpenInterval = false }},
				new UnionOfIntervals.Interval() {left = new UnionOfIntervals.Entry() {value = 5, isOpenInterval = false}, right = new UnionOfIntervals.Entry() {value = 7, isOpenInterval = true }},
				new UnionOfIntervals.Interval() {left = new UnionOfIntervals.Entry() {value = 7, isOpenInterval = false}, right = new UnionOfIntervals.Entry() {value = 8, isOpenInterval = true }},
				new UnionOfIntervals.Interval() {left = new UnionOfIntervals.Entry() {value = 8, isOpenInterval = false}, right = new UnionOfIntervals.Entry() {value = 11, isOpenInterval = true }},
				new UnionOfIntervals.Interval() {left = new UnionOfIntervals.Entry() {value = 9, isOpenInterval = true}, right = new UnionOfIntervals.Entry() {value = 11, isOpenInterval = false }},
				new UnionOfIntervals.Interval() {left = new UnionOfIntervals.Entry() {value = 12, isOpenInterval = false}, right = new UnionOfIntervals.Entry() {value = 14, isOpenInterval = false }},
				new UnionOfIntervals.Interval() {left = new UnionOfIntervals.Entry() {value = 12, isOpenInterval = true}, right = new UnionOfIntervals.Entry() {value = 16, isOpenInterval = false }},
				new UnionOfIntervals.Interval() {left = new UnionOfIntervals.Entry() {value = 13, isOpenInterval = true}, right = new UnionOfIntervals.Entry() {value = 15, isOpenInterval = true }},
				new UnionOfIntervals.Interval() {left = new UnionOfIntervals.Entry() {value = 16, isOpenInterval = true}, right = new UnionOfIntervals.Entry() {value = 17, isOpenInterval = true }},
			};

			UnionOfIntervals.FindUnionOfIntervals(intervals).
				ShouldBeEquivalentTo(new List<UnionOfIntervals.Interval>()
				{
					new UnionOfIntervals.Interval() {left = new UnionOfIntervals.Entry() {value = 0, isOpenInterval = true}, right = new UnionOfIntervals.Entry() {value = 4, isOpenInterval = false }},
					new UnionOfIntervals.Interval() {left = new UnionOfIntervals.Entry() {value = 5, isOpenInterval = false}, right = new UnionOfIntervals.Entry() {value = 11, isOpenInterval = false }},
					new UnionOfIntervals.Interval() {left = new UnionOfIntervals.Entry() {value = 12, isOpenInterval = false}, right = new UnionOfIntervals.Entry() {value = 17, isOpenInterval = true }}
				});
		}
	}
}
