using EPI.Sorting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Sorting
{
	[TestClass]
	public class InPlaceMergeSortUnitTest
	{
		[TestMethod]
		public void InPlaceMerge()
		{
			int?[] A = new int?[] { 5, 13, 17, null, null, null, null, null };
			int?[] B = new int?[] { 3, 7, 11, 19 };
			InPlaceMergeSort.Sort(A, B);
			A.ShouldBeEquivalentTo(new int?[] { 3, 5, 7, 11, 13, 17, 19, null });
		}
	}
}
