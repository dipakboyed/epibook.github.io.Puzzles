namespace EPI.BinaryTree
{
	/// <summary>
	/// Design an algorithm to compute the successor of a node in a binary tree.
	/// Assume that each node stores it's parent.
	/// The successor is the node that appears immediately after the given node in an inorder traversal.
	/// </summary>
	public static class FindSuccessorInorderTraversal<T>
	{
		public static BinaryTreeNode<T> FindSuccessor(BinaryTreeNode<T> node)
		{
			if (node != null)
			{
				if (node.Right != null) //right subtree exists
				{
					// in-order traversal means successor will be in the right subtree
					BinaryTreeNode<T> current = node.Right;

					// it will be the leftmost node in the right subtree
					while (current.Left != null)
					{
						current = current.Left;
					}
					return current;
				}

				// right subtree doesnt exist
				if (node.Parent != null)
				{
					// walk up to parents to find the successor
					BinaryTreeNode<T> next = node.Parent;

					while (next != null && node.Equals(next.Right))
					{
						// current node is the right child of the next node
						// keep walking back up the ancestors
						node = next;
						next = next.Parent;
					}

					// current node is the left child of the next node
					// return next node
					return next;
				}
			}

			return null;
		}
	}
}
