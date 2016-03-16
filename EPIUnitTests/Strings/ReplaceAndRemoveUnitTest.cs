using Microsoft.VisualStudio.TestTools.UnitTesting;

using EPI.Strings;

using FluentAssertions;

namespace EPI.UnitTests.Strings
{
	[TestClass]
	public class ReplaceAndRemoveUnitTest
	{
		[TestMethod]
		public void ReplaceRemoveString()
		{
			ReplaceAndRemove.ReplaceRemove("baacbdb".ToCharArray()).ShouldBeEquivalentTo(new[] {'d','d','d','d','c','d','\0'});
			ReplaceAndRemove.ReplaceRemove("b".ToCharArray()).ShouldBeEquivalentTo(new[] {'\0'});
			ReplaceAndRemove.ReplaceRemove("a ".ToCharArray()).ShouldBeEquivalentTo(new[] {'d','d'});
		}
	}
}
