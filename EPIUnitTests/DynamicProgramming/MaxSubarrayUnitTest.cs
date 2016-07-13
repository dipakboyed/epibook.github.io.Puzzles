using System;
using EPI.DynamicProgramming;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.DynamicProgramming
{
	[TestClass]
	public class MaxSubarrayUnitTest
	{
		[TestMethod]
		public void FindMaxSubarray()
		{
			MaxSubarray.FindMaximumSubarray(new[] { 0, 5, -3, 7, 1, 0, -2 }).ShouldBeEquivalentTo( new Tuple<int, int>(0,6));
			MaxSubarray.FindMaximumSubarray(new[] { 0, -5, -2, 7, 3, -3 }).ShouldBeEquivalentTo(new Tuple<int, int>(3,5));
			MaxSubarray.FindMaximumSubarray(new[] { -1, -5, -2, -7, -3, 0 }).ShouldBeEquivalentTo(new Tuple<int, int>(5, 6));
			MaxSubarray.FindMaximumSubarray(new[] { 0, -1, -5, -2, -7, -3 }).ShouldBeEquivalentTo(new Tuple<int, int>(6, 6));
		}
	}
}
