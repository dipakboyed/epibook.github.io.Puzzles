using System.Collections.Generic;

namespace EPI.BinaryTree
{
	/// <summary>
	/// Write a function that computes the exterior of a binary tree.
	/// The exterior is the following sequence of nodes:
	///   the nodes from the root to the leftmost leaf,
	///   followed by the leaves in left-to-right order,
	///   followed by the nodes from the rightmost leaf to the root
	/// </summary>
	public static class BinaryTreeExterior<T>
	{
		public static List<T> PrintExterior(BinaryTreeNode<T> root)
		{
			List<T> result = new List<T>();
			if (root != null)
			{
				result.Add(root.Value);
			}
			PrintLeftSubtreeExteriorAndLeaves(root.Left, result, true);
			PrintRightSubtreeLeavesAndExterior(root.Right, result, true);
			return result;
		}

		private static void PrintLeftSubtreeExteriorAndLeaves(BinaryTreeNode<T> node, List<T> result, bool isNonLeafExterior)
		{
			if (node != null)
			{
				if (isNonLeafExterior || IsLeafNode(node))
				{
					result.Add(node.Value);
				}
				PrintLeftSubtreeExteriorAndLeaves(node.Left,result, isNonLeafExterior);
				PrintLeftSubtreeExteriorAndLeaves(node.Right, result, isNonLeafExterior && node.Left == null);
			}
		}

		private static void PrintRightSubtreeLeavesAndExterior(BinaryTreeNode<T> node, List<T> result, bool isNonLeafExterior)
		{
			if (node != null)
			{
				PrintRightSubtreeLeavesAndExterior(node.Left, result, isNonLeafExterior && node.Right == null);
				PrintRightSubtreeLeavesAndExterior(node.Right, result, isNonLeafExterior);
				if (isNonLeafExterior || IsLeafNode(node))
				{
					result.Add(node.Value);
				}
			}
		}

		private static bool IsLeafNode(BinaryTreeNode<T> node)
		{
			return (node != null && node.Left == null && node.Right == null);
		}
	}
}
