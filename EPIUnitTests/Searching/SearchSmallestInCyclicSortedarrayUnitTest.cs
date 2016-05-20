using EPI.Searching;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Searching
{
	[TestClass]
	public class SearchSmallestInCyclicSortedArrayUnitTest
	{
		private readonly int[] _cyclicSortedDistinctArray = new[] { 378, 478, 550, 631, 103, 203, 220, 234, 279, 368 };
		private readonly int[] _cyclicSortedArray = new[] { 378, 478, 550, 631, 631, 103, 103, 103, 220, 220, 279, 368 };

		[TestMethod]
		public void SearchSmallestInCyclicSortedArray()
		{
			BinarySearchCyclicSortedArray.SearchSmallest(_cyclicSortedDistinctArray).Should().Be(4);
			BinarySearchCyclicSortedArray.SearchSmallest(_cyclicSortedArray).Should().Be(5);
		}
	}
}
