using EPI.Recursion;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Recursion
{
	[TestClass]
	public class TowersOfHanoiUnitTest
	{
		[TestMethod]
		public void TowersOfHanoiSorting()
		{
			TowersOfHanoi.TransferPegs(4);
			TowersOfHanoi.pegs[0].Count.Should().Be(0);
			TowersOfHanoi.pegs[2].Count.Should().Be(4);
			for (int i= 1; i <= 4; i++)
			{
				TowersOfHanoi.pegs[2].Pop().Should().Be(i);
			}
		}
	}
}
