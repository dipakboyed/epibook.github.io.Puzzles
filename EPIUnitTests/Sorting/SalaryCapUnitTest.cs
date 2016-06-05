using EPI.Sorting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Sorting
{
	[TestClass]
	public class SalaryCapUnitTest
	{
		[TestMethod]
		public void FindSalary()
		{
			SalaryCap.FindSalaryCap(new double[] { 20, 40, 100, 30, 90 }, 210).Should().Be(60);
		}
	}
}
