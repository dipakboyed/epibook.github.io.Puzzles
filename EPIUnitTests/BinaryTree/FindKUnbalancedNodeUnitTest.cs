using EPI.BinaryTree;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.BinaryTree
{
	[TestClass]
	public class FindKUnbalancedNodeUnitTest
	{
		[TestMethod]
		public void FindK_UnbalancedNode()
		{
			BinaryTree<char> tree = new BinaryTree<char>()
			{
				Root = new BinaryTreeNode<char>('A')
				{
					Left = new BinaryTreeNode<char>('B')
					{
						Left = new BinaryTreeNode<char>('C')
						{
							Left = new BinaryTreeNode<char>('D'),
							Right = new BinaryTreeNode<char>('E')
						},
						Right = new BinaryTreeNode<char>('F')
						{
							Right = new BinaryTreeNode<char>('G')
							{
								Left = new BinaryTreeNode<char>('H')
							}
						}
					},
					Right = new BinaryTreeNode<char>('I')
					{
						Left = new BinaryTreeNode<char>('J')
						{
							Right = new BinaryTreeNode<char>('K')
							{
								Left = new BinaryTreeNode<char>('L')
								{
									Right = new BinaryTreeNode<char>('M')
								},
								Right = new BinaryTreeNode<char>('N')
							}
						},
						Right = new BinaryTreeNode<char>('O')
						{
							Left = new BinaryTreeNode<char>('P')
						}
					}
				}
			};
			FindK_UnbalancedNode<char>.FindKUnbalacedNode(tree.Root, 3).Value.Should().Be('J');
		}
	}
}
