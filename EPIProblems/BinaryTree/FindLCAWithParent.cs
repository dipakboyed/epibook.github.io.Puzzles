using System;

namespace EPI.BinaryTree
{
	/// <summary>
	/// Design an algorithm for computing the LCA (least common ancestor) of two nodes
	/// in a binary tree in which nodes have a parent field.
	/// The solution without parent field required traversing from the root downwards.
	/// But when the parent field is available, we can traverse upwards from the two given nodes
	/// </summary>
	/// <remarks> Computing LCA has real world applications like computing the CSS styles that are
	/// applicable to a particular DOM element in the web page's HTML
	/// </remarks>
	public static class FindLCAWithParent<T>
	{
		public static BinaryTreeNode<T> FindLCAWithParentField(BinaryTreeNode<T> root, BinaryTreeNode<T> node1, BinaryTreeNode<T> node2)
		{
			int depth1 = GetNodeDepth(node1);
			int depth2 = GetNodeDepth(node2);
			if (depth2 > depth1)
			{
				Swap(ref node1, ref node2);
			}

			// move up until both nodes have same depth
			int move = 0;
			while (move < Math.Abs(depth2 - depth1) && node1 != null)
			{
				move++;
				node1 = node1.Parent;
			}

			// now that both nodes are at the same depth, traverse up in parallel until we reach a common ancestor
			while (node1 != null && node2 != null)
			{
				if (node1.Equals(node2))
				{
					return node1; //found common ancestor
				}
				node1 = node1.Parent;
				node2 = node2.Parent;
			}

			return null; //no common ancestor
		}

		private static void Swap(ref BinaryTreeNode<T> node1, ref BinaryTreeNode<T> node2)
		{
			BinaryTreeNode<T> temp = node1;
			node1 = node2;
			node2 = temp;
		}

		private static int GetNodeDepth(BinaryTreeNode<T> node)
		{
			int depth = 0;
			while(node != null)
			{
				depth++;
				node = node.Parent;
			}
			return depth;
		}
	}
}
