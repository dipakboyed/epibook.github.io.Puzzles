using System.Collections.Generic;
using EPI.Sorting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Sorting
{
	[TestClass]
	public class RemoveDuplicatesUnitTest
	{
		[TestMethod]
		public void RemoveDuplicatesFromArray()
		{
			List<int> A = new List<int>() { 6, 2, 1, 6, 0, 0, -1 };
			RemoveDuplicates<int>.SortAndRemoveDuplicates(ref A);
			A.ShouldBeEquivalentTo(new List<int>{ -1, 0, 1, 2, 6 });
		}
	}
}
