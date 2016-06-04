using EPI.Sorting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Sorting
{
	[TestClass]
	public class IntersectSortedArraysUnitTest
	{
		[TestMethod]
		public void IntersectTwoSortedArrays()
		{
			IntersectSortedArrays<int>.IntersectionOfTwoSortedArrays(
				new[] { 1, 2, 3, 4, 5, 6 }, new[] { 2, 4, 6, 8, }).ShouldBeEquivalentTo(new[] { 2, 4, 6 });
		}
	}
}
