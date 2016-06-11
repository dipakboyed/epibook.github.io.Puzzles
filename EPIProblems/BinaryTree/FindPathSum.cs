namespace EPI.BinaryTree
{
	/// <summary>
	/// Write a function that takes an integer and a binary tree with integer node values and checks
	/// if there exists a leaf node whose path weight equals the given integer.
	/// Path weight of a node is the sum of the integers on the unique path from the root to that node
	/// </summary>
	public static class FindPathSum
	{
		public static bool HasPathWeight(int weight, BinaryTreeNode<int> root)
		{
			return PathWeightHelper(weight, root, 0);
		}

		private static bool PathWeightHelper(int weight, BinaryTreeNode<int> node, int pathSumSoFar)
		{
			if (node == null)
			{
				return false;
			}

			pathSumSoFar += node.Value;
			if (node.Left == null && node.Right == null) //leaf nodes
			{
				return pathSumSoFar == weight;
			}

			return PathWeightHelper(weight, node.Left, pathSumSoFar) || PathWeightHelper(weight, node.Right, pathSumSoFar);
		}
	}
}
