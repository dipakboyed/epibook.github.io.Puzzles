using Microsoft.VisualStudio.TestTools.UnitTesting;

using EPI.Strings;

namespace EPI.UnitTests.Strings
{
	[TestClass]
	public class PalindromeUnitTest
	{
		[TestMethod]
		public void IsPalindrome_Cases()
		{
			Assert.IsTrue(Palindrome.IsPalindrome(null));
			Assert.IsTrue(Palindrome.IsPalindrome(""));
			Assert.IsTrue(Palindrome.IsPalindrome(" "));
			Assert.IsTrue(Palindrome.IsPalindrome("radar"));
			Assert.IsTrue(Palindrome.IsPalindrome("A man, aplan, a canal, Panama"));
			Assert.IsTrue(Palindrome.IsPalindrome("Able was I, ere I saw Elba!"));
			Assert.IsFalse(Palindrome.IsPalindrome("Ray a ray"));
		}
	}
}
