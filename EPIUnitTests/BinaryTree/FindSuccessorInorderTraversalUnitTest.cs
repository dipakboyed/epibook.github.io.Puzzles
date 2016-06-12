using System.Collections.Generic;
using EPI.BinaryTree;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.BinaryTree
{
	[TestClass]
	public class FindSuccessorInorderTraversalUnitTest
	{
		[TestMethod]
		public void FindInorderSuccessor()
		{
			BinaryTree<char> tree = new BinaryTree<char>()
			{
				Root = new BinaryTreeNode<char>('A')
				{
					Left = new BinaryTreeNode<char>('B')
					{
						Left = new BinaryTreeNode<char>('C')
						{
							Right = new BinaryTreeNode<char>('D')
						},
						Right = new BinaryTreeNode<char>('E')
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
					}
				}
			};

			FindSuccessorInorderTraversal<char>.FindSuccessor(tree.Root).Value.Should().Be('H');
			FindSuccessorInorderTraversal<char>.FindSuccessor(tree.Root.Left).Value.Should().Be('F');
			FindSuccessorInorderTraversal<char>.FindSuccessor(tree.Root.Right).Should().BeNull();

			FindSuccessorInorderTraversal<char>.FindSuccessor(tree.Root.Left.Left).Value.Should().Be('D');
			FindSuccessorInorderTraversal<char>.FindSuccessor(tree.Root.Left.Left.Right).Value.Should().Be('B');
			FindSuccessorInorderTraversal<char>.FindSuccessor(tree.Root.Left.Right).Value.Should().Be('A');
			FindSuccessorInorderTraversal<char>.FindSuccessor(tree.Root.Left.Right.Left).Value.Should().Be('E');
		}
	}
}
