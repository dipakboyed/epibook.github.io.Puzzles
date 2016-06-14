using EPI.DynamicProgramming;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.DynamicProgramming
{
	[TestClass]
	public class LevenshteinDistanceUnitTest
	{
		[TestMethod]
		public void ComputeMinEditLevenshteinDistance()
		{
			LevenshteinDistance.ComputeMinimumEdits("cat", "cats").Should().Be(1);
			LevenshteinDistance.ComputeMinimumEdits("bats", "bat").Should().Be(1);
			LevenshteinDistance.ComputeMinimumEdits("cat", "cap").Should().Be(1);
			LevenshteinDistance.ComputeMinimumEdits("Carthorse", "Orchestra").Should().Be(8);
		}
	}
}
