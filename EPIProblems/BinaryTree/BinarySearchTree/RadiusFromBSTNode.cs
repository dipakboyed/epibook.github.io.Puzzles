using System.Collections.Generic;

namespace EPI.BinaryTree.BinarySearchTree
{
	public static class RadiusFromBSTNode
	{
		public static List<int> FindAllNodesWithinRadius(BinaryTreeNode<int> node, int val, int radius)
		{
			List<int> result = new List<int>();
			// iterate BST and put all ancestors in a stack
			Stack<BinaryTreeNode<int>> stack = new Stack<BinaryTreeNode<int>>();
			bool found = AddPathToNode(node, val, stack);

			if (found)
			{
				int dist = 0;
				HashSet<BinaryTreeNode<int>> visited = new HashSet<BinaryTreeNode<int>>();
				while (dist <= radius && stack.Count > 0)
				{
					BinaryTreeNode<int> curr = stack.Pop();
					FindNodesWithinSubTree(curr, radius - dist, visited, result);
					dist++;
				}
			}
			return result;
		}

		static void FindNodesWithinSubTree(BinaryTreeNode<int> node, int r, HashSet<BinaryTreeNode<int>> visited, List<int> result)
		{
			if (r >= 0 && node != null && !visited.Contains(node))
			{
				visited.Add(node);
				result.Add(node.Value);

				FindNodesWithinSubTree(node.Left, r - 1, visited, result);
				FindNodesWithinSubTree(node.Right, r - 1, visited, result);
			}
		}

		static bool AddPathToNode(BinaryTreeNode<int> node, int val, Stack<BinaryTreeNode<int>> stack)
		{
			if (node != null)
			{
				stack.Push(node);
				if (node.Value == val)
				{
					return true;
				}
				else if (node.Value > val)
				{
					return AddPathToNode(node.Left, val, stack);
				}
				else
				{
					return AddPathToNode(node.Right, val, stack);
				}
			}
			return false;
		}
	}
}
