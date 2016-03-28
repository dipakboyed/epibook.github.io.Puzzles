using EPI.Arrays;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Arrays
{
	[TestClass]
	public class IncrementBigIntUnitTest
	{
		[TestMethod]
		public void BigIntIncrement()
		{
			int[] numberNine = new int[] { 9 };
			IncrementBigInt.Increment(ref numberNine);
			numberNine.Should().ContainInOrder(1, 0);

			int[] numberZero = new int[] { 0 };
			IncrementBigInt.Increment(ref numberZero);
			numberZero.Should().ContainInOrder(1);

			int[] numberNinetyNine = new int[] { 9, 9 };
			IncrementBigInt.Increment(ref numberNinetyNine);
			numberNinetyNine.Should().ContainInOrder(1, 0, 0);

			int[] numberOneTwentyNine = new int[] { 1, 2, 9 };
			IncrementBigInt.Increment(ref numberOneTwentyNine);
			numberOneTwentyNine.Should().ContainInOrder(1, 3, 0);
		}
	}
}
