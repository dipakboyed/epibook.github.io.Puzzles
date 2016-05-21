using EPI.Searching;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Searching
{
	[TestClass]
	public class SquareRootUnitTest
	{
		[TestMethod]
		public void IntegerSquareRoot()
		{
			SquareRoot.IntegerSquareRoot(16).Should().Be(4);
			SquareRoot.IntegerSquareRoot(300).Should().Be(17);
			SquareRoot.IntegerSquareRoot(0).Should().Be(0);
			SquareRoot.IntegerSquareRoot(1).Should().Be(1);
			SquareRoot.IntegerSquareRoot(130).Should().Be(11);
		}

		[TestMethod]
		public void DoubleSquareRoot()
		{
			SquareRoot.DoubleSquareRoot(16).Should().Be(4);
			SquareRoot.DoubleSquareRoot(1.0/4.0).Should().Be(1.0/2.0);
		}
	}
}
