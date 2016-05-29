using System;
using EPI.HashTables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.HashTables
{
	[TestClass]
	public class LongestContainedRangeUnitTest
	{
		[TestMethod]
		public void FindLongestContiguousRange()
		{
			LongestContainedRange.FindLongestContainedRange(new[] { 3, -2, 7, 9, 8, 1, 2, 0, -1, 5, 8 }).ShouldBeEquivalentTo(new Tuple<int, int>(-2, 3));
		}
	}
}
