using Microsoft.VisualStudio.TestTools.UnitTesting;

using EPI.Strings;

namespace EPI.UnitTests.Strings
{
	[TestClass]
	public class WordsReversalUnitTest
	{
		[TestMethod]
		public void ReverseWords_Cases()
		{
			Assert.IsNull(WordsReversal.ReverseWords(null));
			Assert.AreEqual("", WordsReversal.ReverseWords(""));
			Assert.AreEqual(" a  ", WordsReversal.ReverseWords("  a "));
			Assert.AreEqual("Bob likes Alice", WordsReversal.ReverseWords("Alice likes Bob"));
			Assert.AreEqual("   World  Hello ", WordsReversal.ReverseWords(" Hello  World   "));
		}
	}
}
