using Microsoft.VisualStudio.TestTools.UnitTesting;

using EPI.Strings;
using FluentAssertions;

namespace EPI.UnitTests.Strings
{
	[TestClass]
	public class SinusoidalUnitTest
	{
		[TestMethod]
		public void SnakeString()
		{
			Sinusoidal.SnakeString("Hello World!").Should().Be("e lHloWrdlo!");
		}
	}
}
