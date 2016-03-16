using EPI.Arrays;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Arrays
{
	[TestClass]
	public class EnumeratePrimeUnitTest
	{
		[TestMethod]
		public void GenerateAllPrimesFrom1ToN()
		{
			EnumeratePrime.GenerateAllPrimesFrom1toN(-10).Should().BeNull();
			EnumeratePrime.GenerateAllPrimesFrom1toN(0).Should().BeNull();
			EnumeratePrime.GenerateAllPrimesFrom1toN(1).Should().ContainInOrder(1);
			EnumeratePrime.GenerateAllPrimesFrom1toN(2).Should().ContainInOrder(1,2);
			EnumeratePrime.GenerateAllPrimesFrom1toN(3).Should().ContainInOrder(1,2,3);
			EnumeratePrime.GenerateAllPrimesFrom1toN(4).Should().ContainInOrder(1,2,3);
			EnumeratePrime.GenerateAllPrimesFrom1toN(10).Should().ContainInOrder(1,2,3,5,7);
			EnumeratePrime.GenerateAllPrimesFrom1toN(100).Should().ContainInOrder(1,2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67,71,73,79,83,89,97);
		}
	}
}
