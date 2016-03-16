using Microsoft.VisualStudio.TestTools.UnitTesting;

using EPI.Strings;
using FluentAssertions;

namespace EPI.UnitTests.Strings
{
	[TestClass]
	public class EliasGammaEncodingUnitTest
	{
		[TestMethod]
		public void EliasGammaEncode_Cases()
		{
			EliasGammaEncoding.EliasGammaEncode(new[] {13}).Should().Be("0001101");
			EliasGammaEncoding.EliasGammaEncode(new[] { 1, 2, 3 }).Should().Be("1010011");
			EliasGammaEncoding.EliasGammaEncode(new[] { 10, 100, 1000 }).Should().Be("000101000000011001000000000001111101000");
		}

		[TestMethod]
		public void EliasGammaDecode_Cases()
		{
			EliasGammaEncoding.EliasGammaDecode("0001101").ShouldBeEquivalentTo(new[] { 13});
			EliasGammaEncoding.EliasGammaDecode("000101000000011001000000000001111101000").ShouldBeEquivalentTo(new[] { 10, 100, 1000 });
			EliasGammaEncoding.EliasGammaDecode("1010011").ShouldBeEquivalentTo(new[] { 1, 2,3 });
		}
	}
}
