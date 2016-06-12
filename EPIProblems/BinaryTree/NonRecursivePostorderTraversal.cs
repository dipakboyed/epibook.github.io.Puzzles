using System.Collections.Generic;

namespace EPI.BinaryTree
{
	/// <summary>
	/// Write a non-recursive program for performing an inorder traversal on a binary tree.
	/// Assume nodes do not have parent fields.
	/// </summary>
	/// <remarks>
	/// Using recursion, inorder traversal takes up O(h) space where h is the height of the tree.
	/// </remarks>
	public static class NonRecursivePostorderTraversal<T>
	{
		#region Implementation without parent field

		public static List<T> PrintPostorderTraversal(BinaryTreeNode<T> root)
		{
			Stack<BinaryTreeNode<T>> nodes = new Stack<BinaryTreeNode<T>>();
			HashSet<BinaryTreeNode<T>> visited = new HashSet<BinaryTreeNode<T>>();
			if (root != null)
			{
				nodes.Push(root);
			}
			List<T> result = new List<T>();

			while (nodes.Count > 0)
			{
				var current = nodes.Peek();
				if (current.Left != null && !visited.Contains(current.Left))
				{
					nodes.Push(current.Left);
				}
				else if (current.Right != null && !visited.Contains(current.Right))
				{
					nodes.Push(current.Right);
				}
				else
				{
					result.Add(nodes.Pop().Value);
					visited.Add(current);
				}
			}

			return result;
		}

		// Another implementation
		public static List<T> PostorderUsingInvertedPreorder(BinaryTreeNode<T> root)
		{
			List<T> result = InvertedPreorder(root);
			result.Reverse();
			return result;
		}

		private static List<T> InvertedPreorder(BinaryTreeNode<T> node)
		{
			Stack<BinaryTreeNode<T>> nodes = new Stack<BinaryTreeNode<T>>();
			if (node != null)
			{
				nodes.Push(node);
			}
			List<T> result = new List<T>();

			while(nodes.Count > 0)
			{
				var current = nodes.Pop();
				result.Add(current.Value);

				if (current.Left != null)
				{
					nodes.Push(current.Left);
				}
				if (current.Right != null)
				{
					nodes.Push(current.Right);
				}
			}
			return result;
		}

		#endregion

		#region Non-Recursive implementation with Parent field

		public static List<T> PostorderWithParent(BinaryTreeNode<T> root)
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
					// move to left subtree, or right subtree or up if no subtree
					next = (current.Left != null) ? current.Left : (current.Right != null) ? current.Right : current.Parent;
				}
				else if (previous.Equals(current.Right))
				{
					// moving up from the right subtree
					next = current.Parent;
				}
				else
				{
					// moving up from the left subtree
					// visit right subtree or parent
					next = (current.Right != null) ? current.Right : current.Parent;
				}

				if (next == current.Parent)
				{
					// if moving back up, visit current node
					result.Add(current.Value);
				}

				previous = current;
				current = next;
			}

			return result;
		}

		#endregion

		#region Recursive implementation

		//And for completeness, here is the recursive implementation
		public static List<T> PostorderRecursive(BinaryTreeNode<T> root)
		{
			List<T> result = new List<T>();
			PostorderRecursiveHelper(root, result);
			return result;
		}

		private static void PostorderRecursiveHelper(BinaryTreeNode<T> node, List<T> result)
		{
			if (node == null)
			{
				return;
			}
			PostorderRecursiveHelper(node.Left, result);
			PostorderRecursiveHelper(node.Right, result);
			result.Add(node.Value);
		}

		#endregion
	}
}
