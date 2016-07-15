using System.Collections.Generic;
using EPI.HashTables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.HashTables
{
	[TestClass]
	public class TrieShortestUniquePrefixUnitTest
	{
		[TestMethod]
		public void FinsShortestUniquePrefixNotPresent()
		{
			TrieShortestUniquePrefix.FindShortestUniquePrefix("cat", new HashSet<string>()
			{ "dog", "be", "cut", "car"}).Should().Be("cat");
		}
	}
}
