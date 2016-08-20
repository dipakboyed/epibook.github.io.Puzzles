using EPI.DynamicProgramming;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.DynamicProgramming
{
	[TestClass]
	public class BinomialCoefficientsUnitTest
	{
		[TestMethod]
		public void NChooseK()
		{
			BinomialCoefficients.ComputeNChooseK(5, 2).Should().Be(10);
		}
	}
}
