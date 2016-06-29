using EPI.Recursion;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Recursion
{
	[TestClass]
	public class RegexMatchingUnitTest
	{
		[TestMethod]
		public void ESRERegexMatching()
		{
			RegexMatching.IsMatch("Hello World", "^Hello").Should().BeTrue();
			RegexMatching.IsMatch("Hello World", "^Helo").Should().BeFalse();

			RegexMatching.IsMatch("Hello World", "World$").Should().BeTrue();
			RegexMatching.IsMatch("Hello World", "Hello$").Should().BeFalse();

			RegexMatching.IsMatch("Hello World", "^Hello.*d$").Should().BeTrue();
			RegexMatching.IsMatch("Hello World", "^Hello*$").Should().BeFalse();

			RegexMatching.IsMatch("Hello World", "ell. W").Should().BeTrue();
			RegexMatching.IsMatch("Hello World", "Hellw").Should().BeFalse();

			RegexMatching.IsMatch("Hello World", "^Hel*o*.*").Should().BeTrue();
			RegexMatching.IsMatch("Hello World", "Helloa*").Should().BeTrue();
			RegexMatching.IsMatch("Hello World", "Wa*rld").Should().BeFalse();

			RegexMatching.IsMatch("Hello World", "^Hello.*").Should().BeTrue();
			RegexMatching.IsMatch("Hello World", "^Hello.* ").Should().BeTrue();
			RegexMatching.IsMatch("Hello World", "^Hello.*A").Should().BeFalse();
		}
	}
}
