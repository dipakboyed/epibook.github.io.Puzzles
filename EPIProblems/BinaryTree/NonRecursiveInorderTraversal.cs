using System.Collections.Generic;

namespace EPI.BinaryTree
{
	/// <summary>
	/// Write a non-recursive program for performing an inorder traversal on a binary tree.
	/// Assume nodes have parent fields.
	/// </summary>
	/// <remarks>
	/// Using recursion, inorder traversal takes up O(h) space where h is the height of the tree.
	/// </remarks>
	public static class NonRecursiveInorderTraversal<T>
	{
		public static List<T> PrintInorderTraversal(BinaryTreeNode<T> root)
		{
			List<T> result = new List<T>();
			BinaryTreeNode<T> current = root;
			BinaryTreeNode<T> previous = null;

			while (current != null)
			{
				BinaryTreeNode<T> next = null;

				if (previous == null || (previous.Left != null && previous.Left.Equals(current)) || (previous.Right != null && previous.Right.Equals(current)))
				{
					// current is a child of the previous, we are moving in downward direction

					//move to leftmost subtree
					if (current.Left != null)
					{
						next = current.Left;
					}
					else // no more left nodes
					{
						result.Add(current.Value);

						// go right or move up
						next = (current.Right == null) ? current.Parent : current.Right;
					}
				}
				else if (current.Left != null && current.Left.Equals(previous))
				{
					// previous was the left child of current, we are moving up to the parent 
					// after iterating the left Subtree
					result.Add(current.Value);

					// go right or move up
					next = (current.Right == null) ? current.Parent : current.Right;
				}
				else // done with left/right child, move up
				{
					next = current.Parent;
				}

				previous = current;
				current = next;
			}
			return result;
		}
	}
}
