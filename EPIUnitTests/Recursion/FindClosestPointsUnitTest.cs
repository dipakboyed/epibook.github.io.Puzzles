using EPI.Recursion;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Recursion
{
	[TestClass]
	public class FindClosestPointsUnitTest
	{
		[TestMethod]
		public void FindClosestPointsIn2DPlane()
		{
			var result = FindClosestPoints.FindPointsWithClosestDistance(new[]
			{
				new FindClosestPoints.Point(0,-8),
				new FindClosestPoints.Point(9,0),
				new FindClosestPoints.Point(5,2),
				new FindClosestPoints.Point(5,0),
				new FindClosestPoints.Point(2,2)
			});

			result.Item1.ShouldBeEquivalentTo(new FindClosestPoints.Point(5, 2));
			result.Item2.ShouldBeEquivalentTo(new FindClosestPoints.Point(5,0));
		}
	}
}
