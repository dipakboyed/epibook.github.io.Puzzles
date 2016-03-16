using Microsoft.VisualStudio.TestTools.UnitTesting;

using EPI.Strings;
using FluentAssertions;

namespace EPI.UnitTests.Strings
{
	[TestClass]
	public class RunLengthEncodingUnitTest
	{
		[TestMethod]
		public void RleEncode_Cases()
		{
			RunLengthEncoding.RleEncode("aaaabcccaa").Should().Be("4a1b3c2a");
			RunLengthEncoding.RleEncode("aaaabcccaaz").Should().Be("4a1b3c2a1z");
			RunLengthEncoding.RleEncode("a").Should().Be("1a");
		}

		[TestMethod]
		public void RleDecode_Cases()
		{
			RunLengthEncoding.RleDecode("4a1b3c2a").Should().Be("aaaabcccaa");
			RunLengthEncoding.RleDecode("4a1b3c2a1z").Should().Be("aaaabcccaaz");
			RunLengthEncoding.RleDecode("1a").Should().Be("a");
		}
	}
}
