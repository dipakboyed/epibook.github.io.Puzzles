using EPI.HashTables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.HashTables
{
	[TestClass]
	public class TestForPalindromeUnitTest
	{
		[TestMethod]
		public void FindPalindromePermutations()
		{
			TestForPalindrome.CanWordBeAPalindrome("edified").Should().BeTrue();
			TestForPalindrome.CanWordBeAPalindrome("level").Should().BeTrue();
			TestForPalindrome.CanWordBeAPalindrome("levels").Should().BeFalse();
		}
	}
}
