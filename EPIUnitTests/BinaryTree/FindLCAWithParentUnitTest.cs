using EPI.BinaryTree;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.BinaryTree
{
	[TestClass]
	public class FindLCAWithParentUnitTest
	{
		[TestMethod]
		public void FindLCAWithParent()
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

			FindLCAWithParent<char>.FindLCAWithParentField(tree.Root, nodeC, nodeD).Value.Should().Be('B');
			FindLCAWithParent<char>.FindLCAWithParentField(tree.Root, nodeF, nodeJ).Value.Should().Be('A');
			FindLCAWithParent<char>.FindLCAWithParentField(tree.Root, nodeF, nodeX).Should().BeNull();
		}
	}
}
