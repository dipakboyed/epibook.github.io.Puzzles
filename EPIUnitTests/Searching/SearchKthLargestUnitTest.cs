using EPI.Searching;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Searching
{
	[TestClass]
	public class SearchKthLargestUnitTest
	{
		[TestMethod]
		public void SearchKthLargestItem()
		{
			int[] array = new[] { 3, 2, 1, 5, 4 };
			SearchKthLargest.Search(array, 3).Should().Be(3);
		}
	}
}
