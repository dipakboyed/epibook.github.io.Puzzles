using EPI.BinaryTree;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.BinaryTree
{
	[TestClass]
	public class FindLCAUnitTest
	{
		[TestMethod]
		public void FindLCAWithoutParent()
		{
			BinaryTreeNode<char> nodeX = new BinaryTreeNode<char>('X');

			BinaryTree<char> tree = new BinaryTree<char>()
			{
				Root = new BinaryTreeNode<char>('A')
				{
					Left = new BinaryTreeNode<char>('B')
					{
						Left = new BinaryTreeNode<char>('C')
						{
							Right = new BinaryTreeNode<char>('E')
						},
						Right = new BinaryTreeNode<char>('D')
						{
							Left = new BinaryTreeNode<char>('F')
						}
					},
					Right = new BinaryTreeNode<char>('G')
					{
						Left = new BinaryTreeNode<char>('H')
						{
							Right = new BinaryTreeNode<char>('I')
							{
								Left = new BinaryTreeNode<char>('J')
							}
						}
					},
				}
			};
			BinaryTreeNode<char> nodeC = tree.Root.Left.Left;
			BinaryTreeNode<char> nodeD = tree.Root.Left.Right;
			BinaryTreeNode<char> nodeJ = tree.Root.Right.Left.Right.Left;
			BinaryTreeNode<char> nodeF = tree.Root.Left.Right.Left;

			FindLCA<char>.FindLCAWithoutParentField(tree.Root, nodeC, nodeD).Value.Should().Be('B');
			FindLCA<char>.FindLCAWithoutParentField(tree.Root, nodeJ, nodeF).Value.Should().Be('A');
			FindLCA<char>.FindLCAWithoutParentField(tree.Root, nodeF, nodeX).Should().BeNull();
		}
	}
}
