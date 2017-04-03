using Microsoft.VisualStudio.TestTools.UnitTesting;

using EPI.DynamicProgramming;

using FluentAssertions;

namespace EPI.UnitTests.DynamicProgramming
{
    [TestClass]
	public class Number_WaysUnitTest
	{
		[TestMethod]
		public void NumberOfWays_5x5Array()
		{
			 Number_Ways.NumberOfWays(5, 5).Should().Be(70, because: "");
		}
	}
}
