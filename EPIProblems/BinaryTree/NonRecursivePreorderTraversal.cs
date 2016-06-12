using System.Collections.Generic;

namespace EPI.BinaryTree
{
	/// <summary>
	/// Write a non-recursive program for performing a preorder traversal on a binary tree.
	/// Assume nodes do not have parent fields.
	/// </summary>
	public static class NonRecursivePreorderTraversal<T>
	{
		#region Non-Recursive implementation without Parent field

		// Implementation without parent field
		public static List<T> PrintPreorderTraversal(BinaryTreeNode<T> root)
		{
			// we can use a Stack to replace the recursive call stack frames
			List<T> result = new List<T>();
			Stack<BinaryTreeNode<T>> nodes = new Stack<BinaryTreeNode<T>>();
			if (root != null)
			{
				nodes.Push(root);
			}
			while (nodes.Count > 0)
			{
				BinaryTreeNode<T> current = nodes.Pop();
				result.Add(current.Value);

				if (current.Right != null)
				{
					nodes.Push(current.Right);
				}

				if (current.Left != null)
				{
					nodes.Push(current.Left);
				}
			}
			return result;
		}

		#endregion

		#region Non-Recursive implementation with Parent field

		// Implementation with parent field
		public static List<T> PrintPreorderTraversalWithParent(BinaryTreeNode<T> root)
		{
			BinaryTreeNode<T> current = root;
			BinaryTreeNode<T> previous = null;
			List<T> result = new List<T>();

			while (current != null)
			{
				BinaryTreeNode<T> next = null;
				if (previous == null || (previous.Left != null && previous.Left.Equals(current)) || (previous.Right != null && previous.Right.Equals(current)))
				{
					// current is a child of the previous node, we are moving downwards
					// mark current node as visited
					result.Add(current.Value);

					next = (current.Left != null) ? current.Left : (current.Right != null) ? current.Right : current.Parent;
				}
				else if (current.Left != null && current.Left.Equals(previous))
				{
					// we are moving back to the parent after iterating the left subtree

					// next move to right subtree or go back up
					next = (current.Right != null) ? current.Right : current.Parent;
				}
				else
				{
					// we are moving back to the parent after iterating the right subtree
					// go back up
					next = current.Parent;
				}

				previous = current;
				current = next;
			}

			return result;
		}

		#endregion

		#region Recursive implementation

		//And for completeness, here is the recursive preorder traversal
		public static List<T> PreorderRecursive(BinaryTreeNode<T> root)
		{
			List<T> result = new List<T>();
			PreorderRecursiveHelper(root, result);
			return result;
		}

		private static void PreorderRecursiveHelper(BinaryTreeNode<T> node, List<T> result)
		{
			if (node == null)
			{
				return;
			}

			result.Add(node.Value);
			PreorderRecursiveHelper(node.Left, result);
			PreorderRecursiveHelper(node.Right, result);
		}

		#endregion
	}
}
