using EPI.BinaryTree;
using EPI.Recursion;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Recursion
{
	[TestClass]
	public class EnumerateBinaryTreeUnitTest
	{
		[TestMethod]
		public void ListAllBinaryTrees()
		{
			EnumerateBinaryTree<char>.FindAllBinaryTrees(2).Should().HaveCount(2);
			EnumerateBinaryTree<char>.FindAllBinaryTrees(3).Should().HaveCount(5);
		}
	}
}
