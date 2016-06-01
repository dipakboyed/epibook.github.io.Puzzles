using EPI.PrimitiveTypes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.PrimitiveTypes
{
	[TestClass]
	public class GCDUnitTest
	{
		[TestMethod]
		public void ComputeGCD()
		{
			GCD.OptimalApproach(12, 150).Should().Be(GCD.EulersApproach(12, 150));
			GCD.FasterEulersApproach(12, 150).Should().Be(GCD.OptimalApproach(12, 150));
		}
	}
}
