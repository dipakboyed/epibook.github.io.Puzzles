using System.Collections.Generic;
using EPI.BinaryTree;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.BinaryTree
{
	[TestClass]
	public class ComputeRightSiblingUnitTest
	{
		[TestMethod]
		public void FindRightSibling()
		{
			BinaryTreeNodeWithNext<char> Root = new BinaryTreeNodeWithNext<char>('A')
			{
				Left = new BinaryTreeNodeWithNext<char>('B')
				{
					Left = new BinaryTreeNodeWithNext<char>('C')
					{
						Left = new BinaryTreeNodeWithNext<char>('D'),
						Right = new BinaryTreeNodeWithNext<char>('E')
					},
					Right = new BinaryTreeNodeWithNext<char>('F')
					{
						Left = new BinaryTreeNodeWithNext<char>('G'),
						Right = new BinaryTreeNodeWithNext<char>('H')
					}
				},
				Right = new BinaryTreeNodeWithNext<char>('I')
				{
					Left = new BinaryTreeNodeWithNext<char>('J')
					{
						Left = new BinaryTreeNodeWithNext<char>('K'),
						Right = new BinaryTreeNodeWithNext<char>('L')
					},
					Right = new BinaryTreeNodeWithNext<char>('M')
					{
						Left = new BinaryTreeNodeWithNext<char>('N'),
						Right = new BinaryTreeNodeWithNext<char>('O')
					}
				}
			};

			ComputeRightSibling<char>.SetRightSibling(Root);
			Root.Next.Should().BeNull();
			Root.Left.Next.Should().Be(Root.Right);
			Root.Left.Left.Next.Should().Be(Root.Left.Right);

		}
	}
}
