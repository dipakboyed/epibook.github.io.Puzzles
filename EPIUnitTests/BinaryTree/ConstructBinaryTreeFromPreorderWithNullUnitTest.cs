using System.Collections.Generic;
using EPI.BinaryTree;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.BinaryTree
{
	[TestClass]
	public class ConstructBinaryTreeFromInorderWithNullUnitTest
	{
		[TestMethod]
		public void ConstructBinaryTreeFromInorderWithNull()
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

			List<char?> preorderDataWithNull = new List<char?>() { 'A', 'B', 'C', null, 'D', null, null, 'E', 'F', null, null, null, 'G', 'H', null, 'I', 'J',null, null, null, null };

			ConstructBinaryTreeFromPreorderWithNull<char?>.ReconstructTreeFromPreorderDataWithNull(preorderDataWithNull)
				.ShouldBeEquivalentTo(expectedTree.Root, options => options.IgnoringCyclicReferences());
		}
	}
}
