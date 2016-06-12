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
		#region Non-Recursive implementation with Parent field

		// Implementation with parent field
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

		#endregion

		#region Non-Recursive implementation without Parent field

		/// <summary>
		/// We can also implement a non-recursive inorder traversal using a Stack
		/// but that takes up O(h) space.
		/// </summary>
		/// <param name="root"></param>
		/// <returns></returns>
		public static List<T> PrintInorderWithoutParent(BinaryTreeNode<T> root)
		{
			List<T> result = new List<T>();
			Stack<BinaryTreeNode<T>> nodes = new Stack<BinaryTreeNode<T>>();
			HashSet<BinaryTreeNode<T>> visitedNodes = new HashSet<BinaryTreeNode<T>>();
			if (root != null)
			{
				nodes.Push(root);
			}

			while(nodes.Count > 0)
			{
				BinaryTreeNode<T> current = nodes.Peek();
				if (current.Left != null && !visitedNodes.Contains(current.Left))
				{
					nodes.Push(current.Left);
				}
				else
				{
					visitedNodes.Add(nodes.Pop());
					result.Add(current.Value);

					if (current.Right != null && !visitedNodes.Contains(current.Right))
					{
						nodes.Push(current.Right);
					}
				}
			}
			return result;
		}

		#endregion

		#region Recursive implementation

		// And just for completeness, here is the recursive inorder traversal
		public static List<T> PrintInorderRecursive(BinaryTreeNode<T> root)
		{
			List<T> result = new List<T>();
			InorderRecursiveHelper(root, result);
			return result;
		}

		private static void InorderRecursiveHelper(BinaryTreeNode<T> node, List<T> result)
		{
			if (node == null)
			{
				return;
			}

			InorderRecursiveHelper(node.Left, result);
			result.Add(node.Value);
			InorderRecursiveHelper(node.Right, result);
		}

		#endregion
	}
}
