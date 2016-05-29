using System;
using EPI.HashTables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.HashTables
{
	[TestClass]
	public class NearestRepeatedWordsUnitTest
	{
		[TestMethod]
		public void FindNearestRepeatedWords()
		{
			NearestRepeatedWords.FindNearestRepeatedEntries(new[]
				{"All", "work", "and", "no", "play", "makes", "for", "no", "work", "no", "fun", "and", "no", "results" }
			).ShouldBeEquivalentTo(new Tuple<int, int>(7, 9));
		}
	}
}
