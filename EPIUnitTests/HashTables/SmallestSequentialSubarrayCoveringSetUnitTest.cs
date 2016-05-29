using System;
using System.Collections.Generic;
using EPI.HashTables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.HashTables
{
	[TestClass]
	public class SmallestSequentialSubarrayCoveringSetUnitTest
	{
		[TestMethod]
		public void FindSmallestSequentialSubarrayCoveringSet()
		{
			SmallestSequentialSubarrayCoveringSet.FindSmallestSequentialSubarrayOfKeywords(new[]
				{"apple", "banana", "apple", "apple", "dog", "cat", "apple", "dog", "banana", "apple", "cat", "dog" },
			new[] { "dog", "apple" }
			).ShouldBeEquivalentTo(new Tuple<int, int>(4, 6));
		}
	}
}
