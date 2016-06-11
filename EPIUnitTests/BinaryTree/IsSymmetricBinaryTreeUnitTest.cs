using EPI.BinaryTree;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.BinaryTree
{
	[TestClass]
	public class IsSymmetricBinaryTreeUnitTest
	{
		[TestMethod]
		public void IsBinaryTreeSymmetric()
		{
			BinaryTree<int> tree = new BinaryTree<int>()
			{
				Root = new BinaryTreeNode<int>(314)
				{
					Left = new BinaryTreeNode<int>(6)
					{
						Right = new BinaryTreeNode<int>(2)
						{
							Right = new BinaryTreeNode<int>(3)
						}
					},
					Right = new BinaryTreeNode<int>(6)
					{
						Left = new BinaryTreeNode<int>(2)
						{
							Left = new BinaryTreeNode<int>(3)
						}
					}
				}
			};
			IsSymmetricBinaryTree<int>.IsBinaryTreeSymmetric(tree.Root).Should().BeTrue();

			BinaryTree<int> tree2 = new BinaryTree<int>()
			{
				Root = new BinaryTreeNode<int>(314)
				{
					Left = new BinaryTreeNode<int>(6)
					{
						Right = new BinaryTreeNode<int>(561)
						{
							Right = new BinaryTreeNode<int>(3)
						}
					},
					Right = new BinaryTreeNode<int>(6)
					{
						Left = new BinaryTreeNode<int>(2)
						{
							Left = new BinaryTreeNode<int>(1)
						}
					}
				}
			};
			IsSymmetricBinaryTree<int>.IsBinaryTreeSymmetric(tree2.Root).Should().BeFalse();

			BinaryTree<int> tree3 = new BinaryTree<int>()
			{
				Root = new BinaryTreeNode<int>(314)
				{
					Left = new BinaryTreeNode<int>(6)
					{
						Right = new BinaryTreeNode<int>(561)
						{
							Right = new BinaryTreeNode<int>(3)
						}
					},
					Right = new BinaryTreeNode<int>(6)
					{
						Left = new BinaryTreeNode<int>(561)
					}
				}
			};
			IsSymmetricBinaryTree<int>.IsBinaryTreeSymmetric(tree3.Root).Should().BeFalse();
		}
	}
}
