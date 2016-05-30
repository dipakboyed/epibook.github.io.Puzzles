using EPI.Arrays;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Arrays
{
	[TestClass]
	public class SubstringMatchUnitTest
	{
		[TestMethod]
		public void RabinKarpSubstringSearch()
		{
			SubstringMatch.RabinKarp("cat", "catalina").Should().Be(0);
			SubstringMatch.RabinKarp("ali", "catalina").Should().Be(3);
			SubstringMatch.RabinKarp("cat", "catacat").Should().Be(0);

		}
	}
}
