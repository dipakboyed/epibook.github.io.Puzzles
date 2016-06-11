using EPI.BinaryTree;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.BinaryTree
{
	[TestClass]
	public class FindPathSumUnitTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			BinaryTree<int> tree = new BinaryTree<int>()
			{
				Root = new BinaryTreeNode<int>(314)
				{
					Left = new BinaryTreeNode<int>(6)
					{
						Left = new BinaryTreeNode<int>(271)
						{
							Right = new BinaryTreeNode<int>(1)
						},
						Right = new BinaryTreeNode<int>(561)
						{
							Left = new BinaryTreeNode<int>(3)
						}
					},
					Right = new BinaryTreeNode<int>(6)
					{
						Left = new BinaryTreeNode<int>(2)
						{
							Right = new BinaryTreeNode<int>(1)
							{
								Left = new BinaryTreeNode<int>(257)
							}
						}
					},
				}
			};
			FindPathSum.HasPathWeight(592, tree.Root).Should().BeTrue();
			FindPathSum.HasPathWeight(591, tree.Root).Should().BeFalse();
			FindPathSum.HasPathWeight(581, tree.Root).Should().BeFalse();
		}
	}
}
