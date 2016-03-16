using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using EPI.Strings;
using FluentAssertions;

namespace EPI.UnitTests.Strings
{
	[TestClass]
	public class ValidIpAddressUnitTest
	{
		[TestMethod]
		public void ComputeAllValidIpAddresses_Cases()
		{
			ValidIpAddress.ComputeAllValidIpAddresses(null).Should().HaveCount(0);
			ValidIpAddress.ComputeAllValidIpAddresses("").Should().HaveCount(0);
			ValidIpAddress.ComputeAllValidIpAddresses(" ").Should().HaveCount(0);
			ValidIpAddress.ComputeAllValidIpAddresses("123").Should().HaveCount(0);
			ValidIpAddress.ComputeAllValidIpAddresses("0000").ShouldBeEquivalentTo(new List<string> {"0.0.0.0"});
			ValidIpAddress.ComputeAllValidIpAddresses("00000").Should().HaveCount(0);
			ValidIpAddress.ComputeAllValidIpAddresses("19216811").ShouldBeEquivalentTo(new List<string>{
				"1.92.168.11",
				"19.2.168.11",
				"19.21.68.11",
				"19.216.8.11",
				"19.216.81.1",
				"192.1.68.11",
				"192.16.8.11",
				"192.16.81.1",
				"192.168.1.1"
			});
		}
	}
}
