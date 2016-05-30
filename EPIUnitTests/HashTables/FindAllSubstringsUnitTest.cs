using EPI.HashTables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.HashTables
{
	[TestClass]
	public class FindAllSubstringsUnitTest
	{
		[TestMethod]
		public void FindAllSubstringsDecomposition()
		{
			FindAllSubstrings.FindAllSubstringsMatchingWords("amanaplanacanal", new[] { "can", "apl", "ana" }).ShouldBeEquivalentTo(new[] { "aplanacan" });
			FindAllSubstrings.FindAllSubstringsMatchingWords("catdogcatdog", new[] { "cat", "dog" }).ShouldBeEquivalentTo(new[] { "catdog", "dogcat", "catdog" });

		}
	}
}
