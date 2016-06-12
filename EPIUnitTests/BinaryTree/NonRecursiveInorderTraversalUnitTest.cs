using System.Collections.Generic;
using EPI.BinaryTree;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.BinaryTree
{
	[TestClass]
	public class NonRecursiveInorderTraversalUnitTest
	{
		[TestMethod]
		public void PrintNonRecursiveInorderTraversal()
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
			NonRecursiveInorderTraversal<char>.PrintInorderTraversal(tree.Root).ShouldBeEquivalentTo(
				new List<char>() { 'C', 'D', 'B', 'F', 'E', 'A', 'H', 'J', 'I', 'G'});
		}
	}
}
