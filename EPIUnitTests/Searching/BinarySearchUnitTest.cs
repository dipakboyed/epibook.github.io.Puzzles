using Microsoft.VisualStudio.TestTools.UnitTesting;

using EPI.Searching;
using FluentAssertions;

namespace EPI.UnitTests.Searching
{
	[TestClass]
	public class BinarySearchUnitTest
	{
		private readonly int[] _sortedArray = new[] {-14, -10, 2, 108, 108, 243, 285, 285, 285, 401};

		[TestMethod]
		public void RegularBinarySearch()
		{
			BinarySearch.Binary_Search(108, _sortedArray).Should().Be(4);
			BinarySearch.Binary_Search(285, _sortedArray).Should().Be(7);
			BinarySearch.Binary_Search(-10, _sortedArray).Should().Be(1);
			BinarySearch.Binary_Search(0, _sortedArray).Should().Be(-1);
		}

		[TestMethod]
		public void BinarySearchFirstOccurenceOfK()
		{
			BinarySearch.SearchFirstOccurenceOfK(108, _sortedArray).Should().Be(3);
			BinarySearch.SearchFirstOccurenceOfK(285, _sortedArray).Should().Be(6);
			BinarySearch.SearchFirstOccurenceOfK(-14, _sortedArray).Should().Be(0);
			BinarySearch.SearchFirstOccurenceOfK(0, _sortedArray).Should().Be(-1);
		}
	}
}
