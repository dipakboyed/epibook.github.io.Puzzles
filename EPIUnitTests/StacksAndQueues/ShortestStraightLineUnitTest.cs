using System.Collections.Generic;
using EPI.StacksAndQueues;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.StacksAndQueues
{
	[TestClass]
	public class ShortestStraightLineUnitTest
	{
		[TestMethod]
		public void ShortestStraightLineSequence()
		{
			ShortestStraightLine.GetShortestStraightLine(7).ShouldBeEquivalentTo(new List<int> { 1, 2, 3, 4, 7});
			ShortestStraightLine.GetShortestStraightLine(1).ShouldBeEquivalentTo(new List<int> { 1 });
			ShortestStraightLine.GetShortestStraightLine(10).ShouldBeEquivalentTo(new List<int> { 1, 2, 3, 5, 10 });
			ShortestStraightLine.GetShortestStraightLine(15).ShouldBeEquivalentTo(new List<int> { 1, 2, 3, 5, 10, 15 });
		}
	}
}
