using System.Collections.Generic;
using EPI.BinaryTree;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.BinaryTree
{
	[TestClass]
	public class NonRecursivePostorderTraversalUnitTest
	{
		[TestMethod]
		public void PrintNonRecursivePostorderTraversal()
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
			NonRecursivePostorderTraversal<char>.PrintPostorderTraversal(tree.Root).ShouldBeEquivalentTo(
				new List<char>() { 'D', 'C', 'F', 'E', 'B', 'J', 'I', 'H', 'G', 'A' });

			NonRecursivePostorderTraversal<char>.PostorderUsingInvertedPreorder(tree.Root).ShouldBeEquivalentTo(
				new List<char>() { 'D', 'C', 'F', 'E', 'B', 'J', 'I', 'H', 'G', 'A' });

			NonRecursivePostorderTraversal<char>.PostorderWithParent(tree.Root).ShouldBeEquivalentTo(
				new List<char>() { 'D', 'C', 'F', 'E', 'B', 'J', 'I', 'H', 'G', 'A' });

			NonRecursivePostorderTraversal<char>.PostorderRecursive(tree.Root).ShouldBeEquivalentTo(
				new List<char>() { 'D', 'C', 'F', 'E', 'B', 'J', 'I', 'H', 'G', 'A' });
		}
	}
}
