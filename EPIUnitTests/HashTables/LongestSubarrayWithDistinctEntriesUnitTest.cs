using System;
using EPI.HashTables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.HashTables
{
	[TestClass]
	public class LongestSubarrayWithDistinctEntriesUnitTest
	{
		[TestMethod]
		public void FindLongestSubarrayOfDistinctEntries()
		{
			LongestSubarrayWithDistinctEntries.FindLongestSubarrayWithDistinctEntries(new[]
				{'f','s','f','e','t','w','e','n','w','e'}
			).ShouldBeEquivalentTo(new Tuple<int, int>(1, 5));
		}
	}
}
