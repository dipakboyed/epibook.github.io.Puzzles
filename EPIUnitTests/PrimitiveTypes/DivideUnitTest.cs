using EPI.PrimitiveTypes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.PrimitiveTypes
{
	[TestClass]
	public class DivideUnitTest
	{
		[TestMethod]
		public void DivideXbyY()
		{
			Divide.ComputeXDivideByY(1, 1).Should().Be(1);
			Divide.ComputeXDivideByY(2, 1).Should().Be(2);
			Divide.ComputeXDivideByY(5, 2).Should().Be(2);
			Divide.ComputeXDivideByY(22, 7).Should().Be(3);

			Divide.ComputeXDivideByYFaster(1, 1).Should().Be(1);
			Divide.ComputeXDivideByYFaster(2, 1).Should().Be(2);
			Divide.ComputeXDivideByYFaster(5, 2).Should().Be(2);
			Divide.ComputeXDivideByYFaster(22, 7).Should().Be(3);
		}
	}
}

