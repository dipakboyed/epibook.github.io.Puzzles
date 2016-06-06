using EPI.Sorting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Sorting
{
	[TestClass]
	public class HeapSortUnitTest
	{
		[TestMethod]
		public void HeapSortTest()
		{
			int[] A = new[] { 23, 1, 56, 99, 0, -1, 7, 7, 8 };
			HeapSort<int>.Sort(A);
			A.ShouldBeEquivalentTo(new[] { -1, 0, 1, 7, 7, 8, 23, 56, 99 });
		}
	}
}
