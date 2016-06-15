using EPI.HashTables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.HashTables
{
	[TestClass]
	public class DivideAndMarkRepeatsUnitTest
	{
		[TestMethod]
		public void DivideXbyYAndDetectRepeats()
		{
			DivideAndMarkRepeats.DivideXbyY(4, 0).Should().Be("NaN");
			DivideAndMarkRepeats.DivideXbyY(0, 1).Should().Be("0");
			DivideAndMarkRepeats.DivideXbyY(1, 1).Should().Be("1.(0)");
			DivideAndMarkRepeats.DivideXbyY(8, 3).Should().Be("2.(6)");
			DivideAndMarkRepeats.DivideXbyY(-8, 3).Should().Be("-2.(6)");
			DivideAndMarkRepeats.DivideXbyY(8, -3).Should().Be("-2.(6)");
			DivideAndMarkRepeats.DivideXbyY(-8, -3).Should().Be("2.(6)");
			DivideAndMarkRepeats.DivideXbyY(22, 7).Should().Be("3.(142857)");
			DivideAndMarkRepeats.DivideXbyY(10, 7).Should().Be("1.(428571)");
		}
	}
}

