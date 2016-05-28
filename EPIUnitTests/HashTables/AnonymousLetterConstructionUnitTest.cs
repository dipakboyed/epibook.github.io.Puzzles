using EPI.HashTables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.HashTables
{
	[TestClass]
	public class AnonymousLetterConstructionUnitTest
	{
		[TestMethod]
		public void IsAnonymousLetterConstructible()
		{
			AnonymousLetterConstruction.IsLetterConstructibleFromMagazine("I am batman", "Who is batman? I am not").Should().BeTrue();
			AnonymousLetterConstruction.IsLetterConstructibleFromMagazine("I am batman", "Who is batman?").Should().BeFalse();
		}
	}
}
