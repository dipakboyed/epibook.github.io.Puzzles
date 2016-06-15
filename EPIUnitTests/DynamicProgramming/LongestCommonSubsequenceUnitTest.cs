using System.Collections.Generic;
using EPI.DynamicProgramming;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.DynamicProgramming
{
	[TestClass]
	public class LongestCommonSubsequenceUnitTest
	{
		[TestMethod]
		public void ComputeLongestCommonSubsequence()
		{
			LongestCommonSubsequence.ComputeLongestCommonSubsequenceLength("cat", "cats").Should().Be(3);
			LongestCommonSubsequence.ComputeLongestCommonSubsequenceLength("catamaoran", "himoarea").Should().Be(4);

			LongestCommonSubsequence.ListAllLongestCommonSubsequences("cat", "cats").ShouldBeEquivalentTo(new List<string>() { "cat" });
			LongestCommonSubsequence.ListAllLongestCommonSubsequences("catamaoran", "himoarea").ShouldBeEquivalentTo(new List<string>() { "mora", "mara" });
		}
	}
}
