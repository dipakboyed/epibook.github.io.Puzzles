using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using EPI.Strings;
using FluentAssertions;

namespace EPI.UnitTests.Strings
{
	[TestClass]
	public class LookAndSayUnitTest
	{
		[TestMethod]
		public void FindNthNumber_Cases()
		{
			LookAndSay.FindNthNumber(1).Should().Be(1);
			LookAndSay.FindNthNumber(2).Should().Be(11);
			LookAndSay.FindNthNumber(3).Should().Be(21);
			LookAndSay.FindNthNumber(4).Should().Be(1211);
			LookAndSay.FindNthNumber(5).Should().Be(111221);
			LookAndSay.FindNthNumber(6).Should().Be(312211);
			LookAndSay.FindNthNumber(7).Should().Be(13112221);
			LookAndSay.FindNthNumber(8).Should().Be(1113213211);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void FindNthNumber_Invalid()
		{
			LookAndSay.FindNthNumber(0);
		}
	}
}
