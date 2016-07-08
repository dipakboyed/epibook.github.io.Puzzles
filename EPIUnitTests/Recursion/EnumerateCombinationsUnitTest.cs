using System.Collections.Generic;
using EPI.Recursion;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Recursion
{
	[TestClass]
	public class EnumerateCombinationsUnitTest
	{
		[TestMethod]
		public void ListArrayCombinations()
		{
			EnumerateCombinations.NChooseK(new[] { 1, 2, 3, 4, 5 }, 1).ShouldBeEquivalentTo( new List<int[]>()
			{
				new[] {1},
				new[] {2},
				new[] {3},
				new[] {4},
				new[] {5}
			});

			EnumerateCombinations.NChooseK(new[] { 1, 2, 3, 4, 5 }, 2).ShouldBeEquivalentTo(new List<int[]>()
			{
				new[] {1,2},
				new[] {1,3},
				new[] {1,4},
				new[] {1,5},
				new[] {2,3},
				new[] {2,4},
				new[] {2,5},
				new[] {3,4},
				new[] {3,5},
				new[] {4,5},
			});

			EnumerateCombinations.NChooseK(new[] { 1, 2, 3, 4, 5 }, 3).ShouldBeEquivalentTo(new List<int[]>()
			{
				new[] {1,2,3},
				new[] {1,2,4},
				new[] {1,2,5},
				new[] {1,3,4},
				new[] {1,3,5},
				new[] {1,4,5},
				new[] {2,3,4},
				new[] {2,3,5},
				new[] {2,4,5},
				new[] {3,4,5},
			});

			EnumerateCombinations.NChooseK(new[] { 1, 2, 3, 4, 5 }, 4).ShouldBeEquivalentTo(new List<int[]>()
			{
				new[] {1,2,3,4},
				new[] {1,2,3,5},
				new[] {1,2,4,5},
				new[] {1,3,4,5},
				new[] {2,3,4,5},
			});
		}
	}
}
