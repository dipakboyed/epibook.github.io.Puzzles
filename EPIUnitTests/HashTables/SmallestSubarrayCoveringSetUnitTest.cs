using System;
using System.Collections.Generic;
using EPI.HashTables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.HashTables
{
	[TestClass]
	public class SmallestSubarrayCoveringSetUnitTest
	{
		[TestMethod]
		public void FindSmallestSubarrayCoveringSet()
		{
			SmallestSubarrayCoveringSet.FindSmallestSubarrayOfKeywords(new[]
				{"apple", "banana", "apple", "apple", "dog", "cat", "apple", "dog", "banana", "apple", "cat", "dog" },
			new HashSet<string>() { "banana", "cat" }
			).ShouldBeEquivalentTo(new Tuple<int, int>(8, 10));
		}
	}
}
