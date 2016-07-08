using System.Collections.Generic;
using EPI.Recursion;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Recursion
{
	[TestClass]
	public class EnumerateStringOfBalancedParensUnitTest
	{
		[TestMethod]
		public void ListMatchedParens()
		{
			EnumerateStringsOfBalancedParens.ListAllMatchedParens(2).ShouldBeEquivalentTo( new List<string>()
			{"(())", "()()"});

			EnumerateStringsOfBalancedParens.ListAllMatchedParens(3).ShouldBeEquivalentTo(new List<string>()
			{"((()))", "(()())", "(())()", "()(())", "()()()"});
		}
	}
}
