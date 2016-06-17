using EPI.PrimitiveTypes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.PrimitiveTypes
{
	[TestClass]
	public class PowerUnitTest
	{
		[TestMethod]
		public void PowerXbyY()
		{
			Power.XPowerY(1, 1).Should().Be(1);
			Power.XPowerY(2, 0).Should().Be(1);
			Power.XPowerY(5, 2).Should().Be(25);
			Power.XPowerY(22, 7).Should().Be(2494357888);
		}
	}
}

