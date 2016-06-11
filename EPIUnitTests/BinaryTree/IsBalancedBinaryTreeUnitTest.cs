using EPI.BinaryTree;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.BinaryTree
{
	[TestClass]
	public class IsBalancedBinaryTreeUnitTest
	{
		[TestMethod]
		public void IsBinaryTreeBalanced()
		{
			BinaryTree<char> tree = new BinaryTree<char>()
			{
				Root = new BinaryTreeNode<char>('A')
				{
					Left = new BinaryTreeNode<char>('B')
					{
						Left = new BinaryTreeNode<char>('D')
						{
							Left = new BinaryTreeNode<char>('E')
						}
					},
					Right = new BinaryTreeNode<char>('C')
					{
						Left = new BinaryTreeNode<char>('F')
					},
				}
			};
			IsBalancedBinaryTree<char>.IsBinaryTreeBalanced(tree.Root).Should().BeFalse();
			IsBalancedBinaryTree<char>.IsBinaryTreeBalanced(tree.Root.Right).Should().BeTrue();
			IsBalancedBinaryTree<char>.IsBinaryTreeBalanced(tree.Root.Left).Should().BeFalse();
		}
	}
}
