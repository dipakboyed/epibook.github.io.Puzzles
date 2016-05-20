using EPI.Searching;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Searching
{
	[TestClass]
	public class SearchEntryEqualToIndexUnitTest
	{
		private readonly int[] _sortedDistinctArray = new[] { -2, 0, 2, 3, 6, 7, 9};
		private readonly int[] _sortedArray = new[] { -14, -10, 2, 108, 108, 243, 285, 285, 285, 401 };
		private readonly int[] _indexArray = new[] {0, 1, 2, 3, 4, 5, 6};

		[TestMethod]
		public void BinarySearchEntryEqualToItsIndex()
		{
			BinarySearchEntryEqualToIndex.SearchEntryEqualToItsIndex(_sortedDistinctArray).Should().Be(3);
			BinarySearchEntryEqualToIndex.SearchEntryEqualToItsIndex(_sortedArray).Should().Be(2);
			BinarySearchEntryEqualToIndex.SearchEntryEqualToItsIndex(_indexArray).Should().Be(3);
		}
	}
}
