using System;
using EPI.BinaryTree;
using EPI.HashTables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.HashTables
{
	[TestClass]
	public class LCAForCloseAncestorsUnitTest
	{
		[TestMethod]
		public void FindLCAForCloseAncestors()
		{
			BinaryTree<char> tree = new BinaryTree<char>();
			tree.Root = new BinaryTreeNode<char>('A')
			{
				Left = new BinaryTreeNode<char>('B')
				{
					Left = new BinaryTreeNode<char>('D'),
					Right = new BinaryTreeNode<char>('E')
				},
				Right = new BinaryTreeNode<char>('C')
				{
					Left = new BinaryTreeNode<char>('F'),
					Right = new BinaryTreeNode<char>('G')
				}
			};

			LCAForCloseAncestors<char>.FindLCA(tree.Root.Left, tree.Root.Right).Value.Should().Be('A');
			LCAForCloseAncestors<char>.FindLCA(tree.Root.Left.Right, tree.Root.Left.Left).Value.Should().Be('B');
			LCAForCloseAncestors<char>.FindLCA(tree.Root.Right.Left, tree.Root.Right.Right).Value.Should().Be('C');
			LCAForCloseAncestors<char>.FindLCA(tree.Root.Right.Right, tree.Root.Left.Left).Value.Should().Be('A');


			BinaryTree<char> anotherTree = new BinaryTree<char>();
			anotherTree.Root = new BinaryTreeNode<char>('Z')
			{
				Left = new BinaryTreeNode<char>('Y')
			};

			Action action = () =>
			{
				LCAForCloseAncestors<char>.FindLCA(tree.Root.Right.Left, anotherTree.Root.Left);
			};
			action.ShouldThrow<InvalidOperationException>();
		}
	}
}
