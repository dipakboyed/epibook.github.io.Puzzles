namespace EPI.BinaryTree
{
	/// <summary>
	/// You are given a binary tree in which each node has a binary digit.
	/// Design an algorithm to compute the sum of the binary number represented by each root-to-leaf path
	/// </summary>
	public static class SumOfRootToLeafPaths
	{
		public static int FindSumOfAllRootToLeafPaths(BinaryTreeNode<bool> root)
		{
			return SumRootToLeafHelper(root, 0);
		}

		private static int SumRootToLeafHelper(BinaryTreeNode<bool> node, int sumSoFar)
		{
			if (node == null)
			{
				return 0;
			}

			sumSoFar = (2 * sumSoFar) + ((node.Value) ? 1 : 0);
			if (node.Left == null && node.Right == null) //leaf
			{
				return sumSoFar;
			}
			//non-leaf
			return SumRootToLeafHelper(node.Left, sumSoFar) + SumRootToLeafHelper(node.Right, sumSoFar);
		}
	}
}
