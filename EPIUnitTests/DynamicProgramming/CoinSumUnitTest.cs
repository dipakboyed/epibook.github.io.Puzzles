using EPI.DynamicProgramming;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.DynamicProgramming
{
	[TestClass]
	public class CoinSumUnitTest
	{
		[TestMethod]
		public void FindMinCoinsThatSumN()
		{
			CoinSum.FindMinimumCoinsForSumN(new[] { 1, 3, 5 }, 11).Should().Be(3);
		}
	}
}
