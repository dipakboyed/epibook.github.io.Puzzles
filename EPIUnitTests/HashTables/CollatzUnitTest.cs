using EPI.HashTables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.HashTables
{
	[TestClass]
	public class CollatzUnitTest
	{
		[TestMethod]
		public void TestCollatzConjecture()
		{
			Collatz.DoesNumberConvergeToOne(11).Should().BeTrue();
		}
	}
}
