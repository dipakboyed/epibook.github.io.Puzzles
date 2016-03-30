
using EPI.Arrays;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Arrays
{
	[TestClass]
	public class FurthestReachUnitTest
	{

		[TestMethod]
		public void CanReachFurthestArrayItem()
		{
			FurthestReach.CanReachEnd(new [] {3, 3, 1, 0, 2, 0, 1}).Should().BeTrue();
			FurthestReach.CanReachEnd(new[] { 3,2,0,0,2,0,1}).Should().BeFalse();
		}
	}
}
