using EPI.Searching;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Searching
{
	[TestClass]
	public class BinarySearchInTwoSortedArrayUnitTest
	{
		[TestMethod]
		public void SearchKthInTwoSortedArrays()
		{
			int[] A = new[] { 2, 4, 6, 8};
			int[] B = new[] { 1, 3, 5, 7, 9, 11};

			BinarySearchInTwoSortedArrays.SearchKthElement(A, B, 1).Should().Be(1);
			BinarySearchInTwoSortedArrays.SearchKthElement(A, B, 2).Should().Be(2);
			BinarySearchInTwoSortedArrays.SearchKthElement(A, B, 7).Should().Be(7);
			BinarySearchInTwoSortedArrays.SearchKthElement(A, B, 10).Should().Be(11);
			BinarySearchInTwoSortedArrays.SearchKthElement(A, B, 5).Should().Be(5);

		}
	}
}
