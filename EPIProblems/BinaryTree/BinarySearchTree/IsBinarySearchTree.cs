using System.Collections.Generic;

namespace EPI.BinaryTree.BinarySearchTree
{
	public static class IsBinarySearchTree
	{
		public static bool CheckBSTPropertyRecursive(BinaryTreeNode<int> node)
		{
			if (node == null)
			{
				return true;
			}
			else if ((node.Left != null && node.Value < node.Left.Value) || (node.Right != null && node.Value > node.Right.Value))
			{
				return false;
			}

			return CheckBSTPropertyRecursive(node.Left) && CheckBSTPropertyRecursive(node.Right);
		}

		public static bool CheckBSTProperty(BinaryTreeNode<int> root)
		{
			Queue<BinaryTreeNode<int>> nodes = new Queue<BinaryTreeNode<int>>();
			if (root != null)
			{
				nodes.Enqueue(root);
			}

			while (nodes.Count > 0)
			{
				var currentNode = nodes.Dequeue();
				if (currentNode.Left != null)
				{
					if (currentNode.Value < currentNode.Left.Value)
					{
						return false;
					}
					nodes.Enqueue(currentNode.Left);
				}
				if (currentNode.Right != null)
				{
					if (currentNode.Value > currentNode.Right.Value)
					{
						return false;
					}
					nodes.Enqueue(currentNode.Right);
				}
			}

			return true;
		}
	}
}
