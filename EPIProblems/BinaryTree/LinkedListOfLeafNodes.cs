using System.Collections.Generic;

namespace EPI.BinaryTree
{
	/// <summary>
	/// Give a binary tree, compute a linked list from the leaves of the binary tree
	/// where the leaves appear in left-to-right order
	/// </summary>
	public static class LinkedListOfLeafNodes<T>
	{
		public static LinkedList<T> BuildListOfLeafNodes(BinaryTreeNode<T> root)
		{
			LinkedList<T> result = new LinkedList<T>();
			BuildLeafNodesListHelper(root, result);
			return result;
		}

		private static void BuildLeafNodesListHelper(BinaryTreeNode<T> node, LinkedList<T> result)
		{
			if (node == null)
			{
				return;
			}

			// recursively do in-order traversal
			if (node.Left == null && node.Right == null)
			{
				// leaf node
				result.AddLast(node.Value);
			}

			BuildLeafNodesListHelper(node.Left, result);
			BuildLeafNodesListHelper(node.Right, result);
		}
	}
}
