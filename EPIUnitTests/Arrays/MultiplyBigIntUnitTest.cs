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
			MultiplyBigInt.Multiply("12", "13").Should().Be("156");
			MultiplyBigInt.Multiply("-12", "13").Should().Be("-156");
			MultiplyBigInt.Multiply("12", "-13").Should().Be("-156");
			MultiplyBigInt.Multiply("-12", "-13").Should().Be("156");
			MultiplyBigInt.Multiply("11780256934", "150486773289").Should().Be("1772772854513028235926");
		}
	}
}
