using System.Collections.Generic;
using EPI.HashTables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.HashTables
{
	[TestClass]
	public class PartitionAnagramsUnitTest
	{
		[TestMethod]
		public void FindAnagramGroups()
		{
			string[] words = new[] { "debitcard", "elvis", "silent", "badcredit", "lives", "freedom", "listen", "levis" };
			PartitionAnagrams.FindAnagrams(words).ShouldBeEquivalentTo(new List<List<string>>()
			{
				new List<string> { "debitcard", "badcredit"},
				new List<string> { "elvis", "lives", "levis"},
				new List<string> { "silent", "listen"}
			});

		}
	}
}
