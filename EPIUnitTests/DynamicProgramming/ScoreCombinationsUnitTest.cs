using EPI.DynamicProgramming;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.DynamicProgramming
{
	[TestClass]
	public class ScorecombinationsUnitTest
	{
		[TestMethod]
		public void ScoreCombinationsAndPermutations()
		{
			ScoreCombinations.Combinations(12, new[] { 2, 3, 7 }).Should().Be(4);
			ScoreCombinations.Permutations(9, new[] { 2, 3, 7 }).Should().Be(7);
		}
	}
}
