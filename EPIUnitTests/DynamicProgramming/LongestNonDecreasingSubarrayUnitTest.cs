using EPI.DynamicProgramming;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.DynamicProgramming
{
	[TestClass]
	public class LongestNonDecreasingSubarrayUnitTest
	{
		[TestMethod]
		public void FindLengthOfLongestNonDecreasingSubarray()
		{
			LongestNonDecreasingSubarray.FindLengthOfLongestNonDecreasingSubarray(new[] { 3, 4, 8, 6, 7, 5 }).Should().Be(4);
		}
	}
}
