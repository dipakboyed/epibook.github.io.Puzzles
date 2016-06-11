using System;

namespace EPI.BinaryTree
{
	/// <summary>
	/// Design an algorithm for computing the LCA (least common ancestor) of two nodes
	/// in a binary tree in which nodes do not have a parent field
	/// </summary>
	/// <remarks> Computing LCA has real world applications like computing the CSS styles that are
	/// applicable to a particular DOM element in the web page's HTML
	/// </remarks>
	public static class FindLCA<T>
	{
		public static BinaryTreeNode<T> FindLCAWithoutParentField(BinaryTreeNode<T> root, BinaryTreeNode<T> node1, BinaryTreeNode<T> node2)
		{
			return FindLCAHelper(root, node1, node2).Item1;
		}

		// store the matching LCA and count of nodes found in current subtree in a tuple
		private static Tuple<BinaryTreeNode<T>, int> FindLCAHelper(BinaryTreeNode<T> currentNode, BinaryTreeNode<T> node1, BinaryTreeNode<T> node2)
		{
			if (currentNode == null)
			{
				return new Tuple<BinaryTreeNode<T>, int>(null, 0);
			}

			// look for LCA in left and right subtrees
			var leftSubTree  = FindLCAHelper(currentNode.Left, node1, node2);
			if (leftSubTree.Item2 == 2) // found both nodes in left subtree
			{
				return new Tuple<BinaryTreeNode<T>, int>(currentNode.Left, 2);
			}
			var rightSubTree = FindLCAHelper(currentNode.Right, node1, node2);
			if (rightSubTree.Item2 == 2) // found both nodes in right subtree
			{
				return new Tuple<BinaryTreeNode<T>, int>(currentNode.Right, 2);
			}

			int currentNodeFound = 0;
			if (currentNode.Equals(node1) || currentNode.Equals(node2))
			{
				currentNodeFound = 1;
			}
			int noOfNodesFound = leftSubTree.Item2 + rightSubTree.Item2 + currentNodeFound;

			return new Tuple<BinaryTreeNode<T>, int>((noOfNodesFound == 2) ? currentNode: null, noOfNodesFound);
		}
	}
}
