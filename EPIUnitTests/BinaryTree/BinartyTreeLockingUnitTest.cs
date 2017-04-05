using EPI.BinaryTree;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.BinaryTree
{
    [TestClass]
	public class BinaryTreeLockingUnitTest
	{
		[TestMethod]
		public void LockBinaryTree()
		{
			BinaryTreeNodeWithLock<char> Root = new BinaryTreeNodeWithLock<char>('A')
			{
				Left = new BinaryTreeNodeWithLock<char>('B')
				{
					Left = new BinaryTreeNodeWithLock<char>('C')
					{
						Left = new BinaryTreeNodeWithLock<char>('D'),
						Right = new BinaryTreeNodeWithLock<char>('E')
					},
					Right = new BinaryTreeNodeWithLock<char>('F')
					{
						Left = new BinaryTreeNodeWithLock<char>('G'),
						Right = new BinaryTreeNodeWithLock<char>('H')
					}
				},
				Right = new BinaryTreeNodeWithLock<char>('I')
				{
					Left = new BinaryTreeNodeWithLock<char>('J')
					{
						Left = new BinaryTreeNodeWithLock<char>('K'),
						Right = new BinaryTreeNodeWithLock<char>('L')
					},
					Right = new BinaryTreeNodeWithLock<char>('M')
					{
						Left = new BinaryTreeNodeWithLock<char>('N'),
						Right = new BinaryTreeNodeWithLock<char>('O')
					}
				}
			};

			BinaryTreeLocking<char>.IsNodeLocked(Root).Should().BeFalse();
			BinaryTreeLocking<char>.IsNodeLocked(Root.Left).Should().BeFalse();
			BinaryTreeLocking<char>.IsNodeLocked(Root.Right.Right.Right).Should().BeFalse();

			BinaryTreeLocking<char>.LockNode(Root.Left /* B */).Should().BeTrue();
			BinaryTreeLocking<char>.LockNode(Root.Right.Right.Right /* O */).Should().BeTrue();

			BinaryTreeLocking<char>.IsNodeLocked(Root).Should().BeFalse();
			BinaryTreeLocking<char>.IsNodeLocked(Root.Left).Should().BeTrue();
			BinaryTreeLocking<char>.IsNodeLocked(Root.Right.Right.Right).Should().BeTrue();

			BinaryTreeLocking<char>.LockNode(Root).Should().BeFalse();
			BinaryTreeLocking<char>.LockNode(Root.Left.Left).Should().BeFalse();

			BinaryTreeLocking<char>.UnlockNode(Root.Left);

			BinaryTreeLocking<char>.LockNode(Root).Should().BeFalse();
			BinaryTreeLocking<char>.LockNode(Root.Left.Left).Should().BeTrue();
		}
	}
}
