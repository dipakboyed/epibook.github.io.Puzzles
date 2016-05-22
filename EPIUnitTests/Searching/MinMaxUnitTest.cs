using EPI.Searching;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Searching
{
	[TestClass]
	public class MinMaxUnitTest
	{
		[TestMethod]
		public void FindMinMax()
		{
			int[] array = new[] { 3, 2, 5, 1, 2, 4 };
			MinMax.FindMinMax(array).ShouldBeEquivalentTo<MinMax.Pair>(new MinMax.Pair(1, 5));
		}
	}
}
