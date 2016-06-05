using EPI.Sorting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Sorting
{
	[TestClass]
	public class SmallestNonconstructibleChangeUnitTest
	{
		[TestMethod]
		public void FindSmallestChangeNotPossibleToConstruct()
		{
			SmallestNonconstructibleChange.FindSmallestNonconstructibleChange(new[] { 1, 1, 1, 1, 1, 5, 10, 25 }).Should().Be(21);
		}
	}
}
