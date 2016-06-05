using System;
using System.Collections.Generic;
using EPI.Sorting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Sorting
{
	[TestClass]
	public class TaskAssignmentUnitTest
	{
		[TestMethod]
		public void OptimumTaskAsignment()
		{
			TaskAssignment.MinimizeTaskPairs(new[] { 5, 2, 1, 6, 4, 4 }).ShouldBeEquivalentTo(new List<Tuple<int, int>>()
			{
				{ new Tuple<int, int>(1,6)},
				{ new Tuple<int, int>(2,5)},
				{ new Tuple<int, int>(4,4)}
			});
		}
	}
}
