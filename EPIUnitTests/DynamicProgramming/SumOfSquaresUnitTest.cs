using EPI.DynamicProgramming;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.DynamicProgramming
{
	[TestClass]
	public class SumOfSquaresUnitTest
	{
		[TestMethod]
		public void MinimizeSumOfSquares()
		{
			SumOfSquares.MinimizeSumOfSquares(1).Should().Be(1);
			SumOfSquares.MinimizeSumOfSquares(2).Should().Be(2);
			SumOfSquares.MinimizeSumOfSquares(3).Should().Be(3);
			SumOfSquares.MinimizeSumOfSquares(4).Should().Be(1);
			SumOfSquares.MinimizeSumOfSquares(16).Should().Be(1);
			SumOfSquares.MinimizeSumOfSquares(17).Should().Be(2);
		}
	}
}
