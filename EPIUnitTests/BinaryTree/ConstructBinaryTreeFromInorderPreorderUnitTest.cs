using System.Collections.Generic;
using EPI.BinaryTree;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.BinaryTree
{
	[TestClass]
	public class ConstructBinaryTreeFromInorderPreorderUnitTest
	{
		[TestMethod]
		public void ConstructBinaryTreeFromInorderAndPreorder()
		{
			BinaryTree<char> expectedTree = new BinaryTree<char>()
			{
				Root = new BinaryTreeNode<char>('A')
				{
					Left = new BinaryTreeNode<char>('B')
					{
						Left = new BinaryTreeNode<char>('C')
						{
							Left = null,
							Right = new BinaryTreeNode<char>('D')
						},
						Right = new BinaryTreeNode<char>('E')
						{
							Left = new BinaryTreeNode<char>('F'),
							Right = null
						}
					},
					Right = new BinaryTreeNode<char>('G')
					{
						Left = new BinaryTreeNode<char>('H')
						{
							Left = null,
							Right = new BinaryTreeNode<char>('I')
							{
								Left = new BinaryTreeNode<char>('J'),
								Right = null
							}
						},
						Right = null
					}
				}
			};

			List<char> inorderData = new List<char>() { 'C', 'D', 'B', 'F', 'E', 'A', 'H', 'J', 'I', 'G' };
			List<char> preorderData = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

			ConstructBinaryTreeFromInorderPreorder<char>.ReconstructTreeFromInorderAndPreorderData(
				inorderData,
				preorderData)
			.ShouldBeEquivalentTo(expectedTree.Root, options => options.IgnoringCyclicReferences());
		}
	}
}
