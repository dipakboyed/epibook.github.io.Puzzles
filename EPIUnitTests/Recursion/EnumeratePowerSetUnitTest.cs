using System.Collections.Generic;
using EPI.Recursion;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Recursion
{
	[TestClass]
	public class EnumeratePowerSetUnitTest
	{
		[TestMethod]
		public void ListPowerSet()
		{
			EnumeratePowerSet.ListPowerSet(new[] { 'A', 'B', 'C' }).ShouldBeEquivalentTo( new List<List<char>>()
			{
				new List<char>() {},
				new List<char>() {'A'},
				new List<char>() {'B'},
				new List<char>() {'A', 'B'},
				new List<char>() {'C'},
				new List<char>() {'A', 'C'},
				new List<char>() {'B', 'C'},
				new List<char>() {'A', 'B', 'C' }
			});

			EnumeratePowerSet.ListPowerSetViaBitManipulation(new[] { 'A', 'B', 'C' }).ShouldBeEquivalentTo(new List<List<char>>()
			{
				new List<char>() {},
				new List<char>() {'A'},
				new List<char>() {'B'},
				new List<char>() {'A', 'B'},
				new List<char>() {'C'},
				new List<char>() {'A', 'C'},
				new List<char>() {'B', 'C'},
				new List<char>() {'A', 'B', 'C' }
			});
		}
	}
}
