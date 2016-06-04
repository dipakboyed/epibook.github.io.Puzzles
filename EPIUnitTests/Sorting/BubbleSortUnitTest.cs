using EPI.Sorting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Sorting
{
	[TestClass]
	public class BubbleSortUnitTest
	{
		[TestMethod]
		public void BubbleSorting()
		{
			int[] array = new[] { 23, 14, 15, 7, 99, -2, 4, 42 };
			BubbleSort<int>.Sort(array);
			array.ShouldBeEquivalentTo(new[] { -2, 4, 7, 14, 15, 23, 42, 99 });
		}
	}
}
