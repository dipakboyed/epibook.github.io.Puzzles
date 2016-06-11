using EPI.BinaryTree;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.BinaryTree
{
	[TestClass]
	public class SumOfRootToLeafPathsUnitTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			BinaryTree<bool> tree = new BinaryTree<bool>()
			{
				Root = new BinaryTreeNode<bool>(true)
				{
					Left = new BinaryTreeNode<bool>(false)
					{
						Left = new BinaryTreeNode<bool>(false)
						{
							Left = new BinaryTreeNode<bool>(true),
							Right = new BinaryTreeNode<bool>(false)
						},
						Right = new BinaryTreeNode<bool>(true)
						{
							Left = new BinaryTreeNode<bool>(false)
						}
					},
					Right = new BinaryTreeNode<bool>(true)
					{
						Left = new BinaryTreeNode<bool>(false)
						{
							Right = new BinaryTreeNode<bool>(true)
							{
								Left = new BinaryTreeNode<bool>(false)
							}
						}
					},
				}
			};
			SumOfRootToLeafPaths.FindSumOfAllRootToLeafPaths(tree.Root).Should().Be(53);
		}
	}
}
