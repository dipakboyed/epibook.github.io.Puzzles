using EPI.BinaryTree;
using EPI.BinaryTree.BinarySearchTree;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.BinaryTree.BinarySearchTree
{
	[TestClass]
	public class IsBinarySearchTreeUnitTest
	{
		[TestMethod]
		public void CheckIfBinarySearchTree()
		{
			BinaryTree<int> bst = new BinaryTree<int>()
			{
				Root = new BinaryTreeNode<int>(50)
				{
					Left = new BinaryTreeNode<int>(40)
					{
						Left = new BinaryTreeNode<int>(30)
						{
							Right = new BinaryTreeNode<int>(35)
						},
						Right = new BinaryTreeNode<int>(45)
						{
							Left = new BinaryTreeNode<int>(42)
						}
					},
					Right = new BinaryTreeNode<int>(60)
					{
						Left = new BinaryTreeNode<int>(20)
						{
							Right = new BinaryTreeNode<int>(30)
							{
								Left = new BinaryTreeNode<int>(25)
							}
						}
					},
				}
			};

			IsBinarySearchTree.CheckBSTPropertyRecursive(bst.Root).Should().BeTrue();
			IsBinarySearchTree.CheckBSTProperty(bst.Root).Should().BeTrue();
		}
	}
}
