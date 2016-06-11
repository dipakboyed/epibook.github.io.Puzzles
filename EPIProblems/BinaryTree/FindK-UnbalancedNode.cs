using System;

namespace EPI.BinaryTree
{
	/// <summary>
	/// A node in the binary tree is k-balanced if the diference in the number of nodes in the
	/// left subtree and the right subtree is no more than k.
	/// Write a function to find a node in the binary tree that is not k-balanced but all its descendants are
	/// k-balanced.
	/// If no such node exists, return null
	/// </summary>
	public static class FindK_UnbalancedNode<T>
	{
		public static BinaryTreeNode<T> FindKUnbalacedNode(BinaryTreeNode<T> root, int k)
		{
			return KUnbalancedNodeHelper(root, k).Item1;
		}

		// store the current unbalanced node and sum of nodes in current subtree
		private static Tuple<BinaryTreeNode<T>, int> KUnbalancedNodeHelper(BinaryTreeNode<T> node, int k)
		{
			if (node == null) //base case
			{
				return new Tuple<BinaryTreeNode<T>, int>(null, 0);
			}

			var leftSubTree = KUnbalancedNodeHelper(node.Left, k);
			if (leftSubTree.Item1 != null)
			{
				return leftSubTree; // left subtree is k-unbalanced
			}
			var rightSubTree = KUnbalancedNodeHelper(node.Right, k);
			if (rightSubTree.Item1 != null)
			{
				return rightSubTree; // right subtree is k-unbalanced
			}
			//both subtrees are k-balanced
			int noOfNodes = leftSubTree.Item2 + rightSubTree.Item2 + 1;
			if (Math.Abs(leftSubTree.Item2 - rightSubTree.Item2) > k)
			{
				// current node is k-unbalanced
				return new Tuple<BinaryTreeNode<T>, int>(node, noOfNodes);
			}
			else
			{
				return new Tuple<BinaryTreeNode<T>, int>(null, noOfNodes);
			}
		}
	}
}
