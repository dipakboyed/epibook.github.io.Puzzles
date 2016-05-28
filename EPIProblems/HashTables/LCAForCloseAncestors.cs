using System;
using System.Collections.Generic;
using EPI.BinaryTree;

namespace EPI.HashTables
{
	/// <summary>
	/// Design an algorithm for computing the LCA (least common ancestor) of two nodes in a
	/// binary search tree.
	/// The algorithm's time complexity should depend only on the distance from the nodes to the LCA.
	/// It should not need to traverse the whole tree
	/// </summary>
	public static class LCAForCloseAncestors<T>
	{
		public static BinaryTreeNode<T> FindLCA(BinaryTreeNode<T> node1, BinaryTreeNode<T> node2)
		{
			HashSet<BinaryTreeNode<T>> nodesVisited = new HashSet<BinaryTreeNode<T>>();

			// iterate both nodes simultaneously until one of them reaches root
			while (node1 != null || node2 != null)
			{
				if (node1 != null)
				{
					if (!nodesVisited.Contains(node1))
					{
						nodesVisited.Add(node1);
					}
					else
					{
						// node already visited, so we are coming here again
						return node1;
					}
					node1 = node1.Parent;
				}

				if (node2 != null)
				{
					if (!nodesVisited.Contains(node2))
					{
						nodesVisited.Add(node2);
					}
					else
					{
						// node already visited, so we are coming here again
						return node2;
					}
					node2 = node2.Parent;
				}
			}

			throw new InvalidOperationException("Nodes have no common ancestor");
		}
	}
}
