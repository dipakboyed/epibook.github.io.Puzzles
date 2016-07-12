using EPI.Recursion;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Recursion
{
	[TestClass]
	public class PalindromicDecompositionUnitTest
	{
		[TestMethod]
		public void FindAllPalindromeSubstrings()
		{
			PalindromicDecompositions.FindAllPalindromicDecompositions("0204451881").Should().HaveCount(12);
		}
	}
}
