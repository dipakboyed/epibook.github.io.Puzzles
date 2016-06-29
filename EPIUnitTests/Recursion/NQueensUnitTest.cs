using System.Collections.Generic;
using EPI.Recursion;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Recursion
{
	[TestClass]
	public class NQueensUnitTest
	{
		[TestMethod]
		public void FindAllNQueensPlacements()
		{
			NQueens.FindAllNonAttackingNQueensPlacement(4).ShouldBeEquivalentTo(new List<string[]>()
			{
				new string[] {".Q..", "...Q", "Q...", "..Q."},
				new string[] {"..Q.", "Q...", "...Q", ".Q.."}
			});

			NQueens.FindAllNonAttackingNQueensPlacement(8).Should().HaveCount(92);
		}
	}
}
