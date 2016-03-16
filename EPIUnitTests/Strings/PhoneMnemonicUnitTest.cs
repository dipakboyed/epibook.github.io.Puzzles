using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using EPI.Strings;

using FluentAssertions;

namespace EPI.UnitTests.Strings
{
	[TestClass]
	public class PhoneMnemonicUnitTest
	{
		[TestMethod]
		public void ComputeMnemonic()
		{
			PhoneMnemonic.ComputeMnemonic(null).Should().HaveCount(0);
			PhoneMnemonic.ComputeMnemonic("0000000000").Should().HaveCount(1).And.Contain("0000000000");
			PhoneMnemonic.ComputeMnemonic("5678309").Should().HaveCount(3*3*4*3*3*1*4);
		}

		[TestMethod]
		[ExpectedException(typeof (InvalidOperationException))]
		public void ComputeMnemonic_InvalidPhoneNumber()
		{
			PhoneMnemonic.ComputeMnemonic(" ");
		}
	}
}
