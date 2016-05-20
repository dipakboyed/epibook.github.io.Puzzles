using EPI.Arrays;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Arrays
{
	[TestClass]
	public class MultiplyBigIntUnitTest
	{
		[TestMethod]
		public void BigIntMultiply()
		{
			MultiplyBigInt.Multiply("193707721", "-761838257287").Should().Be("-147573952589676412927");
			MultiplyBigInt.Multiply("-193707721", "761838257287").Should().Be("-147573952589676412927");
			MultiplyBigInt.Multiply("-193707721", "-761838257287").Should().Be("147573952589676412927");
			MultiplyBigInt.Multiply("193707721", "761838257287").Should().Be("147573952589676412927");
		}
	}
}
