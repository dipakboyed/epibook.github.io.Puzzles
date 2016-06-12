using EPI.BinaryTree;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Node = EPI.BinaryTree.FindKthNodeInOrderTraversal<char>;
namespace EPI.UnitTests.BinaryTree
{
	[TestClass]
	public class FindKthNodeInOrderTraversalUnitTest
	{
		[TestMethod]
		public void FindKthNodeForInorderTraversal()
		{

			Node.BinaryTreeNodeWithSize<char> Root = new Node.BinaryTreeNodeWithSize<char>('A')
			{
				Left = new Node.BinaryTreeNodeWithSize<char>('B')
				{
					Left = new Node.BinaryTreeNodeWithSize<char>('C')
					{
						Right = new Node.BinaryTreeNodeWithSize<char>('D')
						{
							SubtreeSize = 1
						},
						SubtreeSize = 2
					},
					Right = new Node.BinaryTreeNodeWithSize<char>('E')
					{
						Left = new Node.BinaryTreeNodeWithSize<char>('F')
						{
							SubtreeSize = 1
						},
						SubtreeSize = 2
					},
					SubtreeSize = 5
				},
				Right = new Node.BinaryTreeNodeWithSize<char>('G')
				{
					Left = new Node.BinaryTreeNodeWithSize<char>('H')
					{
						Right = new Node.BinaryTreeNodeWithSize<char>('I')
						{
							Left = new Node.BinaryTreeNodeWithSize<char>('J')
							{
								SubtreeSize = 1
							},
							SubtreeSize = 2
						},
						SubtreeSize = 3
					},
					SubtreeSize = 4
				},
				SubtreeSize = 10
			};
			FindKthNodeInOrderTraversal<char>.FindKthNode(5, Root).Value.Should().Be('E');
			FindKthNodeInOrderTraversal<char>.FindKthNode(1, Root).Value.Should().Be('C');
			FindKthNodeInOrderTraversal<char>.FindKthNode(2, Root).Value.Should().Be('D');
			FindKthNodeInOrderTraversal<char>.FindKthNode(3, Root).Value.Should().Be('B');
			FindKthNodeInOrderTraversal<char>.FindKthNode(4, Root).Value.Should().Be('F');
			FindKthNodeInOrderTraversal<char>.FindKthNode(6, Root).Value.Should().Be('A');
			FindKthNodeInOrderTraversal<char>.FindKthNode(7, Root).Value.Should().Be('H');
			FindKthNodeInOrderTraversal<char>.FindKthNode(8, Root).Value.Should().Be('J');
			FindKthNodeInOrderTraversal<char>.FindKthNode(9, Root).Value.Should().Be('I');
			FindKthNodeInOrderTraversal<char>.FindKthNode(10, Root).Value.Should().Be('G');
			FindKthNodeInOrderTraversal<char>.FindKthNode(11, Root).Should().BeNull();
		}
	}
}
