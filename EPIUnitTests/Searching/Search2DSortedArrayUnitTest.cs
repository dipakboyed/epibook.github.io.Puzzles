using EPI.Searching;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Searching
{
	[TestClass]
	public class Search2DSortedArrayUnitTest
	{
		[TestMethod]
		public void Search2DSorted()
		{
			int[,] array = new[,]
			{
				{-1, 2,  4,  4,  6 },
				{ 1, 5,  5,  9,  21},
				{ 3, 6,  6,  9,  22},
				{ 3, 6,  8,  10, 24},
				{ 6, 8,  9,  12, 25},
				{ 8, 10, 12, 13, 40}
			};
			Search2DSortedArray.Search(array, 8).Should().BeTrue();
			Search2DSortedArray.Search(array, 5).Should().BeTrue();
			Search2DSortedArray.Search(array, 7).Should().BeFalse();
		}
	}
}
