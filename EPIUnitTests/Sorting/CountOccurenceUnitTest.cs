using EPI.Sorting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Sorting
{
	[TestClass]
	public class CountOccurenceUnitTest
	{
		[TestMethod]
		public void CountCharacterOccurence()
		{
			CountOccurence.CountCharacterOccurenceInSortOrder("bcdacebe").Should().Be("(a,1)(b,2)(c,2)(d,1)(e,2)");
		}
	}
}
