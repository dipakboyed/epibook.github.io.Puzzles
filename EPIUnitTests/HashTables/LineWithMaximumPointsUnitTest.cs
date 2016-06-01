using EPI.HashTables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.HashTables
{
	[TestClass]
	public class LineWithMaximumPointsUnitTest
	{
		[TestMethod]
		public void FindLineWithMaxPoints()
		{
			var line = LineWithMaximumPoints.FindLineWithMostPoints(new[]
			{
				new LineWithMaximumPoints.Point(0,0),
				new LineWithMaximumPoints.Point(1,0),
				new LineWithMaximumPoints.Point(0,1),
				new LineWithMaximumPoints.Point(1,1),
				new LineWithMaximumPoints.Point(2,2),
				new LineWithMaximumPoints.Point(2,0),
				new LineWithMaximumPoints.Point(3,3)
			});
			line.Should().Be(new LineWithMaximumPoints.Line(new LineWithMaximumPoints.Point(2, 2), new LineWithMaximumPoints.Point(1,1)));
		}
	}
}
