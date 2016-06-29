﻿using System.Collections.Generic;
using EPI.Recursion;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Recursion
{
	[TestClass]
	public class EnumeratePermutationsUnitTest
	{
		[TestMethod]
		public void ListAllArrayPermutations()
		{
			EnumeratePermutations.ListAllPermutations(new[] { 1, 2, 3 }).ShouldBeEquivalentTo( new List<int[]>()
			{
				new[] {1,2,3},
				new[] {1,3,2},
				new[] {2,1,3},
				new[] {2,3,1},
				new[] {3,2,1},
				new[] {3,1,2}
			});
		}
	}
}
