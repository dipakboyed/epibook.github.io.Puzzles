using System.Collections.Generic;
using EPI.BinaryTree;
using EPI.BinaryTree.BinarySearchTree;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.BinaryTree.BinarySearchTree
{
	[TestClass]
	public class RadiusFromBSTNodeUnitTest
	{
		private BinaryTree<int> bst = new BinaryTree<int>()
		{
			Root = new BinaryTreeNode<int>(100)
			{
				Left = new BinaryTreeNode<int>(50)
				{
					Left = new BinaryTreeNode<int>(25)
					{
						Left = new BinaryTreeNode<int>(12),
						Right = new BinaryTreeNode<int>(37)
					},
					Right = new BinaryTreeNode<int>(75)
					{
						Left = new BinaryTreeNode<int>(63),
						Right = new BinaryTreeNode<int>(87)
					}
				},
				Right = new BinaryTreeNode<int>(150)
				{
					Left = new BinaryTreeNode<int>(125)
					{
						Left = new BinaryTreeNode<int>(112),
						Right = new BinaryTreeNode<int>(137)
					},
					Right = new BinaryTreeNode<int>(175)
					{
						Left = new BinaryTreeNode<int>(163),
						Right = new BinaryTreeNode<int>(187)
					}
				}
			}
		};

		[TestMethod]
		public void FindAllNodesInRadius()
		{
			RadiusFromBSTNode.FindAllNodesWithinRadius(bst.Root, 100, 0).ShouldAllBeEquivalentTo(new List<int>() { 100 });
			RadiusFromBSTNode.FindAllNodesWithinRadius(bst.Root, 100, 1).ShouldAllBeEquivalentTo(new List<int>() { 100, 50, 150 });
			RadiusFromBSTNode.FindAllNodesWithinRadius(bst.Root, 100, 2).ShouldAllBeEquivalentTo(new List<int>() { 100, 50, 150, 25, 75, 125, 175 });
			RadiusFromBSTNode.FindAllNodesWithinRadius(bst.Root, 100, -1).ShouldAllBeEquivalentTo(new List<int>() { });
			RadiusFromBSTNode.FindAllNodesWithinRadius(bst.Root, 1, 0).ShouldAllBeEquivalentTo(new List<int>() { });

			RadiusFromBSTNode.FindAllNodesWithinRadius(bst.Root, 50, 0).ShouldAllBeEquivalentTo(new List<int>() { 50 });
			RadiusFromBSTNode.FindAllNodesWithinRadius(bst.Root, 50, 1).ShouldAllBeEquivalentTo(new List<int>() { 50, 25, 75, 100 });
			RadiusFromBSTNode.FindAllNodesWithinRadius(bst.Root, 50, 2).ShouldAllBeEquivalentTo(new List<int>() { 50, 25, 12, 37, 75, 63, 87, 100, 150 });
			RadiusFromBSTNode.FindAllNodesWithinRadius(bst.Root, 50, 3).ShouldAllBeEquivalentTo(new List<int>() { 50, 25, 12, 37, 75, 63, 87, 100, 150, 125, 175 });
			RadiusFromBSTNode.FindAllNodesWithinRadius(bst.Root, 50, 4).ShouldAllBeEquivalentTo(new List<int>() { 50, 25, 12, 37, 75, 63, 87, 100, 150, 125, 112, 137, 175, 163, 187 });
			RadiusFromBSTNode.FindAllNodesWithinRadius(bst.Root, 50, 5).ShouldAllBeEquivalentTo(new List<int>() { 50, 25, 12, 37, 75, 63, 87, 100, 150, 125, 112, 137, 175, 163, 187 });

			RadiusFromBSTNode.FindAllNodesWithinRadius(bst.Root, 87, 1).ShouldAllBeEquivalentTo(new List<int>() { 87, 75 });
			RadiusFromBSTNode.FindAllNodesWithinRadius(bst.Root, 87, 2).ShouldAllBeEquivalentTo(new List<int>() { 87, 75, 63, 50 });
			RadiusFromBSTNode.FindAllNodesWithinRadius(bst.Root, 63, 3).ShouldAllBeEquivalentTo(new List<int>() { 63, 75, 87, 50, 25, 100 });
			RadiusFromBSTNode.FindAllNodesWithinRadius(bst.Root, 163, 4).ShouldAllBeEquivalentTo(new List<int>() { 163, 175, 187, 150, 125, 112, 137, 100, 50 });
		}
	}
}
