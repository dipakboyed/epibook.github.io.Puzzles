using System.Collections.Generic;

namespace EPI.BinaryTree.BinarySearchTree
{
	/// <summary>
	/// Write a function that takes an integer N and a binary search tree with integer node values and returns the smallest path
	/// from root to leaf whose path weight equals the given integer.
	/// Path weight of a node is the sum of the integers on the unique path from the root to that node.
	/// If no such root to leaf path exists, return an empty path.
	/// Path can be either ordered from leaf-to-root or root-to-leaf
	/// </summary>
	public static class FindSmallestPathSumN
	{
		public static List<int> FindSmallestRootToLeafPathMatchingN(BinaryTreeNode<int> root, int n)
		{
			List<int> path = new List<int>();
			FindPathHelper(root, n, 0, path);
			return path;
		}

		private static bool FindPathHelper(BinaryTreeNode<int> node, int n, int sumSoFar, List<int> path)
		{
			if (node != null)
			{
				// base case
				if (sumSoFar + node.Value == n)
				{
					if (IsLeafNode(node))
					{
						path.Add(node.Value);
						return true;
					}
				}

				if (n - (sumSoFar + node.Value) > node.Value) // remaining sum is greater than current node + sumsofar, look under right subtree
				{
					if (FindPathHelper(node.Right, n, sumSoFar + node.Value, path))
					{
						path.Add(node.Value);
						return true;
					}
				}

				// either there is no right subtree or remaining sum is less than current node +sumSoFar, look under left subtree
				if (FindPathHelper(node.Left, n, sumSoFar + node.Value, path))
				{
					path.Add(node.Value);
					return true;
				}
			}
			return false;
		}

		private static bool IsLeafNode(BinaryTreeNode<int> node)
		{
			return node != null && node.Left == null && node.Right == null;
		}
	}
}
